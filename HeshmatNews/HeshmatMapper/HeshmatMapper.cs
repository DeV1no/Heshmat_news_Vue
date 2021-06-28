using System.Linq;
using System.Linq.Dynamic.Core;
using AutoMapper;
using dadachMovie.DTOs;
using dadachMovie.DTOs.Role;
using HeshmastNews.Convertor;
using HeshmastNews.DTOs;
using HeshmastNews.DTOs.Comment;
using HeshmastNews.DTOs.Role;
using HeshmastNews.DTOs.Tag;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;

namespace HeshmastNews.HeshmatMapper
{
    public class HeshmatMapper : Profile
    {
        public HeshmatMapper()
        {
            //CateGories Map
            CreateMap<Category, CategoryVewModelDTO>().ReverseMap();
            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();

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
                .ForMember(x => x.RoleNames,
                    opt => opt.MapFrom(
                        r => r.Roles.Select(r => r.RoleName))).ReverseMap();
            //Role Mapper
            CreateMap<RoleDTO, Role>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<PermissionViewModelDTO, Permission>().ReverseMap();
            CreateMap<Role, RoleCreateDTO>().ReverseMap();
            CreateMap<RoleSaveDTO, Role>().ReverseMap();
            //Comments Maps
            /*CreateMap<NewsComment, CommentDTO>().ReverseMap();

            CreateMap<UnAcceptedCommentDTO, NewsComment>()
                .ForMember(e => e.User,
                    e => e.MapFrom(c => c.UserName ?? "")).ReverseMap();*/

            // Tag Mapper
            CreateMap<TagViewModelDTO, Tag>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Tag, TagUpdateDTO>().ReverseMap();
            // News Mapper
            CreateMap<News, NewsCreationDTO>().ReverseMap();
            CreateMap<NewsListViewModleDTO, News>().ReverseMap()
                .ForMember(x => x.CreatedDate,
                    opt => opt.MapFrom(q => q.CreatedDate.ToShamsi()));
            CreateMap<NewsHomeViewModelDTO, News>().ReverseMap()
                .ForMember(x => x.CreatedDate,
                    opt => opt.MapFrom(q => q.CreatedDate.ToShamsi()))
                .ForMember(x => x.Poster,
                    opt => opt.MapFrom(q => $"http://localhost:5000/news/image/{q.Poster}"))
                .ForMember(x => x.Categories,
                    opt => opt.MapFrom(q => q.Category));

            CreateMap<NewsSaveDTO, News>().ReverseMap()
                .ForMember(x => x.Poster,
                    opt => opt.MapFrom(q => $"http://localhost:5000/news/image/{q.Poster}"))
                .ForMember(x => x.CategoriesId,
                    opt => opt.MapFrom(q => q.Category.Select(z => z.CategoryId).ToList()))
                .ForMember(x => x.TagsId,
                    opt => opt.MapFrom(q => q.Tags.Select(z => z.Id).ToList()));
        }
    }
}