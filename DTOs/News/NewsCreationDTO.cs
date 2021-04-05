using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HeshmastNews.DTOs;
using HeshmastNews.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.DTOs
{
    public class NewsCreationDTO
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoryId { get; set; }

        public int? SubGroup { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NewsBody { get; set; }


        public string Tags { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public IFormFile Poster { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}