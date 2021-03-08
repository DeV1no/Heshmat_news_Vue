using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.Entities
{
    public class Comment : IId
    {
        [Key] public int Id { get; set; }
        [Required] public string Content { get; set; }

        public int rate { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ComentNews> ComentNews { get; set; }

        public Comment()
        {
            this.DateCreated = DateTime.Now;
        }
    }
}