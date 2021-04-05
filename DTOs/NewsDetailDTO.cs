using System.Collections.Generic;
using dadachMovie.DTOs;
using HeshmastNews.DTOs;

namespace HeshmastNews.Entities
{
    public class NewsDetailDTO : NewsDTO
    {
        public List<CategoriesDTO> Categories { get; set; }
        public List<CommentDTO> Comment { get; set; }
    
    }
}