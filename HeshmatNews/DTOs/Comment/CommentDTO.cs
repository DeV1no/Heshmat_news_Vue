using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.Comment
{
    public class CommentDTO
    {
        public int UserId { get; set; }
        public int NewsId { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string Subject { get; set; }

        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string CommentBody { get; set; }
    }
}