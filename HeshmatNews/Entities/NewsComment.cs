using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeshmastNews.Entities
{
    public class NewsComment
    {
        [Key] public int CommentId { get; set; }
        public int UsersId { get; set; }
        public int NewsId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isAccepted { get; set; }

        // Relation Ship 
     //   [ForeignKey("UsersId")] public User Users { get; set; }
        [ForeignKey("NewsId")] public News News { get; set; }
    }
}