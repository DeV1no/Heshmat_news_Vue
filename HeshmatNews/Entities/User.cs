using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HeshmastNews.Entities
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }


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
        public string Role { get; set; }

        public string Token { get; set; }
        // Relation ship 

        public NewsComment NewsComment { get; set; }
    }
}