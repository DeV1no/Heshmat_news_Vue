using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.DTOs
{
    public class AddCommentDTO
    {
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string Body { get; set; }
        public int NewsId { get; set; }
    }
}
