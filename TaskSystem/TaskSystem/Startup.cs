using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TaskSystem.BL.Utils;
using TaskSystem.Code;
using TaskSystem.DL;

namespace TaskSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var keyByteArray = Encoding.ASCII.GetBytes(Configuration ["SecurityKey"]);
                    var signingKey = new SymmetricSecurityKey(keyByteArray);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = signingKey,
                        ValidAudience = "Audience",
                        ValidIssuer = "Issuer",
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(0)
                    };
                });

            services
                .AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

            services.AddMvc();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext db)
        {

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("AllowAll");

            app.UseMvc();
            InitializeDatabase(app);

            DbInitializer.Initialize(db);


        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
            }
        }
    }
}
