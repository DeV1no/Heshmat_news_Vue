using System.Collections.Generic;
using HeshmastNews.DTOs;
using HeshmastNews.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.DTOs
{
    public class NewsCreationDTO : NewsPatchDTO
    {
        public IFormFile Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<CategoriesDTO>>))]
        public List<CategoriesDTO> Categories { get; set; }
    }
}