using System.Collections.Generic;
using System.Threading.Tasks;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;

namespace dadachMovie.Services.Contracts
{
    public interface IUserService
    {
        bool IsUniqueUser(string username);
        bool IsUniqueEmail(string email);
        UserLoginViewModelDTO Authenticate(UserLoginDTO model);
        UserRegisterViewModelDTO Register(UserRegisterDTO model);
        CurrentUserViewModelDTO GetCurrentUserById(string id);
        User GetUserBySecretCode(string secretKey);
        int ActiveUserBySecretKey(string secretKey);
        int ResetPasswordBySecretKey(string secretKey, string password);
        List<UserListViewModelDTO> GetUserList();
        bool AddRoleToUser(int userId, int roleId);
        bool RemoveRoleToFrom(int userId);
    }
}