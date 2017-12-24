using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskSystem.Code;
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
            return Ok(new { token = generatedToken });
        }

        private string GeneratedToken(User user)
        {
            var claims = new [] { new Claim(ClaimTypes.Name, user.Email) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration ["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var requestAt = DateTime.Now;
            var expiresIn = requestAt.Add(TimeSpan.FromMinutes(30));
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Email, "TokenAuth"),
                new [] {
                    new Claim("Name", user.Email)
                }
            );

            var keyByteArray = Encoding.ASCII.GetBytes("sdfsdfsfsdfdfsfsdf34234234242389o-------------------fsdfsdfsdfsdfsdf");
            var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keyByteArray);
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {

                Issuer = "Issuer",
                Audience = "Audience",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                Subject = identity,
                Expires = expiresIn,
                NotBefore = DateTime.Now.Subtract(TimeSpan.FromMinutes(30))
            });


            //
            //
            //            var identity = GetIdentity(user.Email);
            //
            //            var now = DateTime.UtcNow;
            //            var jwt = new JwtSecurityToken(
            //                issuer: AuthOptions.ISSUER,
            //                audience: AuthOptions.AUDIENCE,
            //                notBefore: now,
            //                claims: identity.Claims,
            //                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            //                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            //            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return handler.WriteToken(securityToken);
        }

        private ClaimsIdentity GetIdentity(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}