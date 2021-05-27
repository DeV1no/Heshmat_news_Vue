using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HeshmastNews.Entities;
using HeshmastNews.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.DTOs
{
    public class CategoryCreationDTO
    {
        public string CateGoryName { get; set; }
        public int? ParentId { get; set; }
    }
}