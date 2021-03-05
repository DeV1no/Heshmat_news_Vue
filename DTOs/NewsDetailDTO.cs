using System.Collections.Generic;
using HeshmastNews.DTOs;

namespace HeshmastNews.Entities
{
    public class NewsDetailDTO : NewsDTO
    {
        public List<CategoriesDTO> Categories { get; set; }
    }
}