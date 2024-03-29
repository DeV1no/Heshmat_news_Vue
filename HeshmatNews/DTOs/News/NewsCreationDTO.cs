using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HeshmastNews.DTOs;
using HeshmastNews.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.DTOs
{
    public class NewsCreationDTO
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List<int> CategoriesId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NewsBody { get; set; }

        public List<int> TagsId { get; set; }

        public IFormFile Poster { get; set; }
        public bool isChoseClerck { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Source { get; set; }

    }
}