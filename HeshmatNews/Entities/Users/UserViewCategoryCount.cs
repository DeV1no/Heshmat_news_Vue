using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeshmastNews.Entities;

namespace dadachMovie.Entities.Users
{
    public class UserViewCategoryCount
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int Count { get; set; }
        // relation

        public User User { get; set; }
        public Category Category { get; set; }
       
    }
}
