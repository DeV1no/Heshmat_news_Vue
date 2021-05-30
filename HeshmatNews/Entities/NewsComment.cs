using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeshmastNews.Entities
{
    public class NewsComment
    {
        [Key] public int CommentId { get; set; }
        public int UserId { get; set; }
        public int NewsId { get; set; }
        public string Subject { get; set; }
        public string CommentBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isAccepted { get; set; }

        // Relation Ship 
        //   [ForeignKey("UsersId")] public User UserId { get; set; }
        [ForeignKey("UsersId")] public User User { get; set; }
        [ForeignKey("NewsId")] public News News { get; set; }
    }
}