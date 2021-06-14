using System.Collections.Generic;
using HeshmastNews.Entities;

namespace HeshmastNews.DTOs.User
{
    public class UserListViewModelDTO
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
       
        public string RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public List<string> RoleNames { get; set; }
     
    }
}