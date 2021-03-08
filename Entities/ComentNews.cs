namespace HeshmastNews.Entities
{
    public class ComentNews
    {
        public int CommentId { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public Comment Comment { get; set; }
    }
}