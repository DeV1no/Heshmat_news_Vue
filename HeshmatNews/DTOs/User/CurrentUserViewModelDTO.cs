using System;
using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.User
{
    public class CurrentUserViewModelDTO
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string NameFamily { get; set; }
        public string Role { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}