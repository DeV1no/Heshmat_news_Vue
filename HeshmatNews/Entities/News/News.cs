using dadachMovie.Entities;
using dadachMovie.Entities.News;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeshmastNews.Entities
{
    public class News
    {
        public News()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int NewsId { get; set; }

        public int? SubGroup { get; set; }

        public string NewsTitle { get; set; }
        public string NewsBody { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Poster { get; set; }

        public DateTime? UpdateTime { get; set; }
        public bool isChoseClerck { get; set; }
        public double rateAverage { get; set; }
        public int rateCount { get; set; }

        //RelationShip
        public User User { get; set; }
        public List<Tag> Tags { get; set; }
        public string Source { get; set; }
        public List<CategoryNews> CategoryNews { get; set; }
        public List<Comment> Comments { get; set; }
        public List<UserRateNews> UserRateNews { get; set; }
    }
}