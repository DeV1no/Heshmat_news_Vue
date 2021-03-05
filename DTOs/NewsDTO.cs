using System;

namespace HeshmastNews.DTOs
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NewsBody { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Poster { get; set; }
    }
}