using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HeshmastNews.Entities
{
    public class Role:IdentityRole<int>
    {
     //   public int Id { get; set; }
        public string RoleName { get; set; }
        //Relation
        public List<User> Users { get; set; }
    }
}