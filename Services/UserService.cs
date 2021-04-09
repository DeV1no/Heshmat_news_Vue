using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace HeshmastNews.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;


        public UserService(ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        public User RegisterUser(UserRegisterViewModelDTO user)
        {
            var userVR = new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                NameFamily = user.NameFamily,
                Password = user.Password,
                UserAvatar = "/User/UserProfile/default.png",
                RegisterDate = DateTime.Now,
                IsDelete = false
            };

            _context.User.Add(userVR);
            _context.SaveChanges();
            return userVR;
        }

        public async Task<UserTokenDTO> BuildToken(UserLoginViewModelDTO userInfo)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.Email),
                new Claim(ClaimTypes.Name, userInfo.Email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            
        //    HttpContext.SignInAsync(principal);

            var identityUser = await _userManager.FindByEmailAsync(userInfo.Email);
          //  var claimsDB = await _userManager.GetClaimsAsync(identityUser);

           // claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}