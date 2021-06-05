using System;
using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.User
{
    public class UserLoginViewModelDTO 
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime  TokenExpires { get; set; }
    }
}