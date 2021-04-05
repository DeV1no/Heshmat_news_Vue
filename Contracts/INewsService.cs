using System.Threading.Tasks;
using dadachMovie.DTOs;

namespace HeshmastNews.Contracts
{
    public interface INewsService:IBaseService
    {
        Task<int> AddUserCommentAsync(CommentCreationDTO commentCreationDTO);
        Task<int> DeleteUserCommentAsync(int id);

    }
}