using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using dadachMovie.Services.Contracts;
using HeshmastNews.Convertor;
using HeshmastNews.Data;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;
using HeshmatNews.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace HeshmastNews.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;


        public UserService(ApplicationDbContext context, IMapper mapper, IOptions<AppSettings> appSettings
        )
        {
            _context = context;
            _mapper = mapper;

            _appSettings = appSettings.Value;
        }


        public bool IsUniqueUser(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }

        public bool IsUniqueEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public UserLoginViewModelDTO Authenticate(UserLoginDTO model)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.UserName == model.Username);
            if (user == null)
            {
                user = _context.Users
                    .SingleOrDefault(u => u.Email == model.Username);
            }

            if (user == null || user.Password != model.Password)
                return null;
            // Create Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.UserData, user.Id.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.TokenExpires = (DateTime) tokenDescriptor.Expires;
            return _mapper.Map<UserLoginViewModelDTO>(user);
            
        }

        public UserRegisterViewModelDTO Register(UserRegisterDTO model)
        {
            bool isUnique = IsUniqueUser(model.UserName);
            if (isUnique)
                return null;

            var userObj = _mapper.Map<User>(model);
            userObj.Role = "User";
            userObj.SecretKey = CharRandomMaker.RandomString(10);
            userObj.RegisterDate = DateTime.Now;
            _context.Users.Add(userObj);
            _context.SaveChanges();
            var userView = _mapper.Map<UserRegisterViewModelDTO>(model);
            return userView;
        }

        public CurrentUserViewModelDTO GetCurrentUserById(string id)
        {
            var userDb = _context.Users.FirstOrDefault(u => u.Id.ToString() == id);
           
            return _mapper.Map<CurrentUserViewModelDTO>(userDb);
        }

        public User GetUserBySecretCode(string secretKey)
        {
            return _context.Users.FirstOrDefault(u => u.SecretKey == secretKey);
        }

        public int ActiveUserBySecretKey(string secretKey)
        {
            var userDb = GetUserBySecretCode(secretKey);
            if (userDb == null)
                return -1;
            if (userDb.IsActive)
                return -2;
            else
            {
                userDb.IsActive = true;
                userDb.SecretKey = CharRandomMaker.RandomString(10);
                _context.Users.Update(userDb);
                _context.SaveChanges();
                return 1;
            }
        }

        public int ResetPasswordBySecretKey(string secretKey, string password)
        {
            var userDb = GetUserBySecretCode(secretKey);

            if (userDb == null)
                return -1;

            else
            {
                userDb.Password = password;
                userDb.SecretKey = CharRandomMaker.RandomString(10);
                _context.Users.Update(userDb);
                _context.SaveChanges();
                return 1;
            }
        }
    }
}