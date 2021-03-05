using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class NewsPatchDTO
    {
        [Required] public string Name { get; set; }
        public string NewsBody { get; set; }
        
    }
}