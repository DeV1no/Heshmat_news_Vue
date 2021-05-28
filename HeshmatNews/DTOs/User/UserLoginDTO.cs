using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.User
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string Username { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string Password { get; set; }
    }
}