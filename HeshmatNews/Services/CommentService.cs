using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs.Comment;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Services
{
    public class CommentService : ICommentService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CommentService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public bool AddComment(CommentDTO model)
        {
            var commentSave = _mapper.Map<NewsComment>(model);
            commentSave.isAccepted = false;
            _context.NewsComments.Add(commentSave);
            if (Save())
                return true;
            return false;
        }

        public List<UnAcceptedCommentDTO> GetUnAcceptedComments()
        {
            var unAcceotedComments = _context.NewsComments
                .Where(c => c.isAccepted == false)
                .Include(u => u.User); //
            var commentView = new List<UnAcceptedCommentDTO>();
            foreach (var item in unAcceotedComments)
            {
                commentView.Add(_mapper.Map<UnAcceptedCommentDTO>(item));
            }

            return commentView;
        }

        public bool AcceptComment(int commentId)
        {
            var commentDb = _context.NewsComments
                .FirstOrDefault(c => c.CommentId == commentId);
            commentDb.isAccepted = false;
            _context.NewsComments.Update(commentDb);
            if (Save())
                return true;
            return false;
        }

        public bool RemoveComment(int commentId)
        {
            var commentDb = _context.NewsComments
                .FirstOrDefault(c => c.CommentId == commentId);
            _context.NewsComments.Remove(commentDb);
            if (Save())
                return true;
            return false;
        }

        private bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}