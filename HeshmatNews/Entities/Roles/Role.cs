using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HeshmastNews.Entities
{
    public class Role : IdentityRole<int>
    {
     
        public string RoleName { get; set; }

        //Relation
        public List<User> Users { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}