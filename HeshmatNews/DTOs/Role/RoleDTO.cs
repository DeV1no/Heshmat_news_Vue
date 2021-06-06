using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs.Role
{
    public class RoleDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        public string RoleName { get; set; }
    }
}