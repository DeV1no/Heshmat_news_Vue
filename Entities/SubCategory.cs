using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.Entities
{
    public class SubCategory : IId
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public List<SubToCat> SubToCat { get; set; }
    }
}