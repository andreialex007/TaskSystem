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
            var identity = new ClaimsIdentity(
                new GenericIdentity(user.Email, "TokenAuth"),
                new []
                {
                    new Claim("Email", user.Email)
                }
            );

            var keyByteArray = Encoding.ASCII.GetBytes(Configuration ["SecurityKey"]);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "Issuer",
                Audience = "Audience",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(30),
                NotBefore = DateTime.Now.Subtract(TimeSpan.FromMinutes(30))
            });

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