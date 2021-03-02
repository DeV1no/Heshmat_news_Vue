namespace HeshmastNews.Entities
{
    public class SubToCat
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}