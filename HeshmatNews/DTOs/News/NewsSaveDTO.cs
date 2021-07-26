using System.Collections.Generic;

namespace HeshmastNews.DTOs.News
{
    public class NewsSaveDTO
    {
        public List<int> CategoriesId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsBody { get; set; }
        public List<int> TagsId { get; set; }
        public string Poster { get; set; }
        public bool  isChoseClerck{ get; set; }

    }
}