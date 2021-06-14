using System.Collections.Generic;

namespace HeshmastNews.DTOs.Role
{
    public class AddPermissionToRoleDTO
    {
        public int RoleId { get; set; }
        public List<int> PermissionIds { get; set; }
    }
}