using System;
using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.Entities
{
    public class User
    {
        [Key] public int UserId { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد")]
        public string Email { get; set; }

        [Required] public string NameFamily { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string Password { get; set; }


        public string UserAvatar { get; set; }

        public DateTime RegisterDate { get; set; }
        public bool IsDelete { get; set; }
    }
}