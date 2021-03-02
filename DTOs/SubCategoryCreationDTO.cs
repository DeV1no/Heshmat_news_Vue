using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HeshmastNews.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.DTOs
{
    public class SubCategoryCreationDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
    //    [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
     //   public List<int> CategoryId { get; set; }
    }
}