using System.Collections.Generic;
using HeshmastNews.DTOs;

namespace dadachMovie.DTOs
{
    public class NewsHomeViewModelDTO:NewsListViewModleDTO
    {
        public string NewsBody { get; set; }
        public string Poster { get; set; }
        public List<CategoryVewModelDTO> Categories { get; set; }
    }
}