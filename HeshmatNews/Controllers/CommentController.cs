using System;
using dadachMovie.Services.Contracts;
using HeshmastNews.DTOs.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.Controllers
{
    [ApiController]
    [Route("api/Comment")]
    public class CommentController : ControllerBase
    {
        private IHttpContextAccessor _httpContextAccessor;
        private ICommentService _commentService;

        public CommentController(IHttpContextAccessor httpContextAccessor, ICommentService commentService)
        {
            _httpContextAccessor = httpContextAccessor;
            _commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public bool AddComment([FromForm] CommentDTO model)
        {
            model.UserId = Int32.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            var commentResult = _commentService.AddComment(model);
            if (commentResult)
                return true;
            return false;
        }

        [HttpPost("acceptComment/{commentId:int}", Name = "acceptComment")]
        [Authorize]
        public bool AcceptComment(int commentId)
        {
            return _commentService.AcceptComment(commentId);
        }

        [HttpDelete("{commentId:int}", Name = "acceptComment")] [Authorize]
        public bool DeleteComment(int commentId)
        {
            return _commentService.RemoveComment(commentId);
        }
    }
}