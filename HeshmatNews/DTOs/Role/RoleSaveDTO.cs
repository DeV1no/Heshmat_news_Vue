using System.Collections.Generic;
using HeshmastNews.DTOs.Role;

namespace HeshmastNews.Entities
{
    public class RoleSaveDTO
    {
        public int id { get; set; }
        public string RoleName { get; set; }
        public List<PermissionViewModelDTO> Permissions { get; set; }

    }
}