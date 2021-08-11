using dadachMovie.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.Services.Contracts
{
    public interface ICommentService
    {
        public Task<int> AddComment(AddCommentDTO model, int userId);
    }
}
