using AutoMapper;
using HeshmastNews.DTOs.Comment;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;

namespace HeshmastNews.HeshmatMapper
{
    public class HeshmatMapper : Profile
    {
        public HeshmatMapper()
        {
            //User Maps 
            CreateMap<User, UserLoginViewModelDTO>().ReverseMap();
            CreateMap<UserRegisterViewModelDTO,UserRegisterDTO>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();
            CreateMap<UserLoginViewModelDTO, User>().ReverseMap();
            CreateMap<CurrentUserViewModelDTO, User>().ReverseMap();
            //Comments Maps
            CreateMap<NewsComment, CommentDTO>().ReverseMap();
            
            CreateMap<UnAcceptedCommentDTO, NewsComment>()
                .ForMember(e=>e.User,
                    e=>e
                        .MapFrom(c=>c.UserName??"")).ReverseMap();
        }
    }
}