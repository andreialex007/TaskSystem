using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskSystem.DL;
using TaskSystem.DL.Entities;
using TaskSystem.ViewModels;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class AccountController : ControllerBase
    {
        public AccountController(IConfiguration configuration, AppDbContext appDbContext)
            : base(configuration, appDbContext)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RequestToken")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            var user = Service.User.Login(request.Username, request.Password);
            var generatedToken = GeneratedToken(user);
            return Ok(new {token = generatedToken});
        }

        private string GeneratedToken(User user)
        {
            var claims = new[] {new Claim(ClaimTypes.Name, user.Email)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                "yourdomain.com",
                "yourdomain.com",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return generatedToken;
        }
    }
}