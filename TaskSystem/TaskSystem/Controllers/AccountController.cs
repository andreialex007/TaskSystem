﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        public AccountController(IConfiguration configuration, AppDbContext appDbContext, IHostingEnvironment environment)
            : base(configuration, appDbContext, environment)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            return Content("test success");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RequestToken")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            var user = Service.User.Login(request.Username, request.Password);
            var generatedToken = GeneratedToken(user);
            return Ok(new
            {
                token = generatedToken,
                userName = user.FirstName
            });
        }

        private string GeneratedToken(User user)
        {
            var claims = new []
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim("Id", user.Id.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration ["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Startup.ValidIssuer,
                Startup.ValidAudience,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return generatedToken;
        }
    }
}