using System.Linq;
using AutoMapper;
using HeshmastNews.Convertor;
using HeshmastNews.DTOs.Comment;
using HeshmastNews.DTOs.Role;
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
            CreateMap<UserRegisterViewModelDTO, UserRegisterDTO>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();
            CreateMap<UserLoginViewModelDTO, User>().ReverseMap();
            CreateMap<CurrentUserViewModelDTO, User>().ReverseMap();
            CreateMap<UserListViewModelDTO, User>().ReverseMap()
                .ForMember(x => x.RegisterDate,
                    opt
                        => opt.MapFrom(r => DateConvertor.ToShamsi(r.RegisterDate)))
                .ForMember(x => x.RoleName,
                    opt => opt.MapFrom(
                        r => r.Role.RoleName)).ReverseMap();
            //Role Mapper
            CreateMap<RoleDTO, Role>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            //Comments Maps
            CreateMap<NewsComment, CommentDTO>().ReverseMap();

            CreateMap<UnAcceptedCommentDTO, NewsComment>()
                .ForMember(e => e.User,
                    e => e
                        .MapFrom(c => c.UserName ?? "")).ReverseMap();
        }
    }
}