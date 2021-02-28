using System.ComponentModel.DataAnnotations;

namespace HeshmastNews.DTOs
{
    public class CategoryCreationDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
    }
}