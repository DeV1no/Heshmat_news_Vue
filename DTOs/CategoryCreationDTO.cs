using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HeshmastNews.Entities;
using HeshmastNews.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.DTOs
{
    public class CategoryCreationDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> CategoryId { get; set; }
    }
}