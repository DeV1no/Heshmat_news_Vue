using HeshmastNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.Entities
{
    public class UserRateNews
    {
        public int NewsId { get; set; }
        public int UserId { get; set; }

        public double Rate { get; set; }
        // relation

        public User User { get; set; }
        public HeshmastNews.Entities.News News { get; set; }
    }
}