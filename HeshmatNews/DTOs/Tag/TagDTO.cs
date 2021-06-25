using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.Tag
{
    public class TagDTO
    {
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string TagName { get; set; }
    }
}