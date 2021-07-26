using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HeshmastNews.DTOs.News
{
    public class NewsUpdateDTO:NewsCreationDTO
    {
        public int NewsId { get; set; }
    }
}