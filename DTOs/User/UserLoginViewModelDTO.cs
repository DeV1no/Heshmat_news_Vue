using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.User
{
    public class UserLoginViewModelDTO
    {
        [Required] [EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}