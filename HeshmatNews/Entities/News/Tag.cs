using System.Collections.Generic;

namespace HeshmastNews.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string TagName { get; set; }

        // Relations
        public List<News> NewsList { get; set; }
    }
}