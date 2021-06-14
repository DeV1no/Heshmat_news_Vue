using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.Role
{
    public class PermissionViewModelDTO
    {
        public int PermissionId { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string permissionTitle { get; set; }

        public int? ParentId { get; set; }
    }
}