using System;

namespace dadachMovie.DTOs
{
    public class NewsListViewModleDTO
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string CreatedDate { get; set; }
        public string UserName { get; set; }
        public bool  isChoseClerck{ get; set; }
    }
}