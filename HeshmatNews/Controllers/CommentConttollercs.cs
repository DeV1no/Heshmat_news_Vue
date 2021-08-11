using dadachMovie.DTOs;
using dadachMovie.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentConttollercs : ControllerBase
    {
        private ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentConttollercs(ICommentService commentService, IHttpContextAccessor httpContextAccessor)
        {
            _commentService = commentService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost("add")]
        [Authorize]
        public Task<int> AddComment(AddCommentDTO model)
           => _commentService.AddComment(model, Convert.ToInt32(_httpContextAccessor.HttpContext.User.Identity.Name));




    }
}
