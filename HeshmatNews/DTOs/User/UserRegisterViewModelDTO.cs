using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HeshmastNews.DTOs.User
{
    public class UserRegisterViewModelDTO
    {
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد")]
        public string Email { get; set; }

        [Required] public string NameFamily { get; set; }

       
       
    }
}