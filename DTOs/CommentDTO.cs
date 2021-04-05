using System;

namespace dadachMovie.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int rate { get; set; }
        public DateTime DateCreated { get; set; }

        
    }
}