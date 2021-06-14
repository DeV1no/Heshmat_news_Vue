using System.Collections.Generic;

namespace HeshmastNews.DTOs.User
{
    public class UserRoleDTO
    {
        public int userId { get; set; }
        public List<int>  roleId { get; set; }
    }
}