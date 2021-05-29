using System.Collections.Generic;
using HeshmastNews.DTOs.Comment;

namespace dadachMovie.Services.Contracts
{
    public interface ICommentService
    {
        bool AddComment(CommentDTO model);
        List<UnAcceptedCommentDTO> GetUnAcceptedComments();
        bool AcceptComment(int commentId);
        bool RemoveComment(int commentId);
    }
}