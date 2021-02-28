using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.Entities
{
    public class Category : IId
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
    }
}