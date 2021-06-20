using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs
{
    public class CategoryVewModelDTO
    {
        public int CategoryId { get; set; }
        public string CateGoryName { get; set; }

        public int? ParentId { get; set; }
    }
}