using System.Collections.Generic;
using System.Threading.Tasks;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;

namespace dadachMovie.Services.Contracts
{
    public interface IUserService
    {
        bool IsUniqueUser(string username);
        UserLoginViewModelDTO Authenticate(UserLoginDTO model);
        UserRegisterViewModelDTO Register(UserRegisterDTO model);
    }
}