namespace HeshmastNews.Entities
{
    public class CategoryNews
    {
        public int CategoryId { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public Category Category { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }

    }
}