using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.User
{
    public class UserRegisterDTO:UserRegisterViewModelDTO
    {
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string Password { get; set; }

    }
}