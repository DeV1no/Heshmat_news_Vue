using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace dadachMovie.DTOs
{
    public class NewsUpdateDTO:NewsCreationDTO
    {
        public int NewsId { get; set; }
    }
}