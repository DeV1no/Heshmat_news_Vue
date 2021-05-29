using AutoMapper;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;

namespace HeshmastNews.HeshmatMapper
{
    public class HeshmatMapper : Profile
    {
        public HeshmatMapper()
        {
            CreateMap<User, UserLoginViewModelDTO>().ReverseMap();
            CreateMap<UserRegisterViewModelDTO,UserRegisterDTO>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();
            CreateMap<UserLoginViewModelDTO, User>().ReverseMap();
            CreateMap<CurrentUserViewModelDTO, User>().ReverseMap();
        }
    }
}