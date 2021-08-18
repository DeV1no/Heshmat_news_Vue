using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.DTOs.User
{
    public class UpdateUserInformationDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string Family { get; set; }


        public string Password { get; set; }

        public IFormFile UserAvatar { get; set; }
        public string PreUserAvatar { get; set; }
    }
}
