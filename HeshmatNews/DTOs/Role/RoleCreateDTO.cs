using System.Collections.Generic;
using HeshmastNews.DTOs.Role;

namespace dadachMovie.DTOs.Role
{
    public class RoleCreateDTO
    {
        public string RoleName { get; set; }
        public List<int> PermissionsId { get; set; }
    }
}