using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeshmastNews.Entities
{
    public class Permission
    {
        [Key] public int PermissionId { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string permissionTitle { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")] public List<Permission> permissions { get; set; }
        public List<Role> Roles { get; set; }
    }
}