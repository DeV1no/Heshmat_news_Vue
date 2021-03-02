using System.Collections.Generic;

namespace HeshmastNews.DTOs
{
    public class SubCategoryDetailDTO : SubCategoriesDTO
    {
        public List<CategoriesDTO> Category { get; set; }
    }
}