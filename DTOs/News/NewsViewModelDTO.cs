using System;
using System.Collections.Generic;
using HeshmastNews.Entities;

namespace dadachMovie.DTOs
{
    public class NewsViewModelDTO
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsBody { get; set; }
        public string Tags { get; set; }
        public string Poster { get; set; }
        public int Category { get; set; }
        public string CreatedDate { get; set; }
        
        public Category Categories { get; set; }

       
    }
}