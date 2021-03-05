using System;
using System.Collections.Generic;

namespace HeshmastNews.Entities
{
    public class News : IId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NewsBody { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Poster { get; set; }

        //  public List<Tags> Tags { get; set; }
        public List<CategoryNews> CategoryNews { get; set; }

        public News()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}