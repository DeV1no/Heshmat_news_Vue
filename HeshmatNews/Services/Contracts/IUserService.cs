using System.Collections.Generic;
using System.Threading.Tasks;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;

namespace dadachMovie.Services.Contracts
{
    public interface IUserService
    {
        User RegisterUser(UserRegisterViewModelDTO user);
       Task <UserTokenDTO> BuildToken(UserLoginViewModelDTO userInfo);
    }
}