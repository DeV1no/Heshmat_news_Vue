using System;

namespace HeshmastNews.DTOs.User
{
    public class UserTokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiration{ get; set; }
    }
}