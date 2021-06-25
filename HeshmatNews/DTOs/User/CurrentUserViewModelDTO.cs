using System;
using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.User
{
    public class CurrentUserViewModelDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}