using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskSystem.ViewModels;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class AccountController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string [] { "value1", "value2" };
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RequestToken")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {

            //            var request = new TokenRequest();
            if (request.Username == "Jon" && request.Password == "Again, not for production use, DEMO ONLY!")
            {
                var claims = new []
                {
                    new Claim(ClaimTypes.Name, request.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration ["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    "yourdomain.com",
                    "yourdomain.com",
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { token = generatedToken });
            }

            return BadRequest("Could not verify username and password");
        }

        public AccountController(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
