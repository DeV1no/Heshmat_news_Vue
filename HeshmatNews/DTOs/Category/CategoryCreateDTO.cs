using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs
{
    public class CategoryCreateDTO
    {
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]

        public string CateGoryName { get; set; }

        public int? ParentId { get; set; }
    }
}