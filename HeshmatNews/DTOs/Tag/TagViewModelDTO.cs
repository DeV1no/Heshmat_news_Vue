namespace HeshmastNews.DTOs.Tag
{
    public class TagViewModelDTO:TagDTO
    {
        public int Id { get; set; }
        public int? UseCount { get; set; }
    }
}