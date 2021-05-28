using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.User
{
    public class UserLoginViewModelDTO 
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}