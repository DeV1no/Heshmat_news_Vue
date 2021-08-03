using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeshmastNews.Entities
{
    public class CategoryNews
    {
        public int CategoryId { get; set; }

        public int NewsId { get; set; }

        //Relations 
        public News News { get; set; }
        public Category Category { get; set; }
    }
}