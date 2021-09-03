using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dadachMovie.Entities.Users;

namespace HeshmastNews.Entities
{
    public class Category
    {
        [Key] public int CategoryId { get; set; }
        [Required] public string CateGoryName { get; set; }
        public int? ParentId { get; set; }

        // RelationShip
        [ForeignKey("ParentId")] public List<Category> Categories { get; set; }//Subcategories

        public List<CategoryNews> CategoryNews { get; set; }
        public List<UserViewCategoryCount> UserViewCategoryCounts { get; set; }


    }
}