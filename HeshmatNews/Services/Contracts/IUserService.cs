using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs.User;
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
        UserListViewModelDTO GetUserDataById(int userId);
        bool AddRoleToUser(int userId, List<int> roleId);
        bool RemoveRoleToFrom(int userId);
        Task<bool> UpdateUserInformation(UpdateUserInformationDTO model);
        Task<UpdateUserInformationDTO> GetUserProfileInfo(int userId);
        Task<bool> UserCategoryViewUpdater(int newsId, int userId);
    }
}