using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.Entities
{
    public class UserInfo
    {
        [Required] [EmailAddress] public string EmailAddress { get; set; }
        [Required] public string Password { get; set; }
    }
}