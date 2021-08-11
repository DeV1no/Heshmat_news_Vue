using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HeshmastNews.Entities;

namespace dadachMovie.Entities.News
{
    public class Comment
    {

        public Comment()
        {
            CreatedDate = DateTime.Now;

        }

        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int NewsId { get; set; }
        //Relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("NewsId")]
        public HeshmastNews.Entities.News News { get; set; }

    }
}
