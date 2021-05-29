namespace HeshmastNews.DTOs.Comment
{
    public class UnAcceptedCommentDTO
    {
        public int CommentId { get; set; }
        public string Subject { get; set; }
        public string Createdate { get; set; }
        public int userId { get; set; }
        public string UserName { get; set; }
    }
}