using AutoMapper;
using dadachMovie.DTOs;
using dadachMovie.Entities.News;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.Services
{
    public class CommentService : ICommentService
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<int> AddComment(AddCommentDTO model, int userId)
        {
            var commentDb = _mapper.Map<Comment>(model);
            commentDb.UserId = userId;
            _context.Comments.Add(commentDb);
            await _context.SaveChangesAsync();
            return commentDb.Id;
        }
    }
}