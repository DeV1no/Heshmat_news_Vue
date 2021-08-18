using System.Linq;
using System.Linq.Dynamic.Core;
using AutoMapper;
using dadachMovie.DTOs;
using dadachMovie.DTOs.Comment;
using dadachMovie.DTOs.Role;
using dadachMovie.DTOs.User;
using dadachMovie.Entities.News;
using HeshmastNews.Convertor;
using HeshmastNews.DTOs;
using HeshmastNews.DTOs.News;
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

            CreateMap<User, UpdateUserInformationDTO>()
                  .ForMember(x => x.UserAvatar,
                            opt => opt.Ignore())

                            .ForMember(x => x.PreUserAvatar,
                            opt => opt.MapFrom(q => q.UserAvatar))
                .ReverseMap()
       .ForAllMembers(m => m.Condition((source, target, sourceValue, targetValue) => sourceValue != null));


            //Role Mapper
            CreateMap<RoleDTO, Role>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<PermissionViewModelDTO, Permission>().ReverseMap();
            CreateMap<Role, RoleCreateDTO>().ReverseMap();
            CreateMap<RoleSaveDTO, Role>().ReverseMap();
            //Comments Maps
            CreateMap<Comment, AddCommentDTO>().ReverseMap();


            // Tag Mapper
            CreateMap<TagViewModelDTO, Tag>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Tag, TagUpdateDTO>().ReverseMap();
            // News Mapper
            /*CreateMap<News, NewsCreationDTO>().ReverseMap()
                .ForMember(x => x.CategoryNews.Select(x => x.Category),
               opt => opt.MapFrom(q => q.CategoriesId));*/



            CreateMap<NewsListViewModleDTO, News>().ReverseMap()

                .ForMember(x => x.UserName,
                    opt => opt.MapFrom(q => q.User.UserName))
                .ForMember(x => x.CreatedDate,
                    opt => opt.MapFrom(q => q.CreatedDate.ToShamsi()));
            CreateMap<NewsHomeViewModelDTO, News>().ReverseMap()
                .ForMember(x => x.UserName,
                    opt => opt.MapFrom(q => q.User.UserName))
                .ForMember(x => x.Name,
                    opt => opt.MapFrom(q => q.User.Name))
                .ForMember(x => x.Family,
                    opt => opt.MapFrom(q => q.User.Family))
                .ForMember(x => x.CreatedDate,
                    opt => opt.MapFrom(q => q.CreatedDate.ToShamsi()))
                .ForMember(x => x.Poster,
                    opt => opt.MapFrom(q => $"http://localhost:5000/news/image/{q.Poster}"))
                .ForMember(x => x.Categories,
                    opt => opt.MapFrom(q => q.CategoryNews.Select(x => x.Category)));

            CreateMap<NewsSingleDTO, News>().ReverseMap()
               .ForMember(x => x.UserName,
                   opt => opt.MapFrom(q => q.User.UserName))
               .ForMember(x => x.Name,
                   opt => opt.MapFrom(q => q.User.Name))
               .ForMember(x => x.Family,
                   opt => opt.MapFrom(q => q.User.Family))
               .ForMember(x => x.CreatedDate,
                   opt => opt.MapFrom(q => q.CreatedDate.ToShamsi()))
               .ForMember(x => x.Poster,
                   opt => opt.MapFrom(q => $"http://localhost:5000/news/image/{q.Poster}"))

                .ForMember(x => x.Tags,
                   opt => opt.MapFrom(q => q.Tags))
                 .ForMember(x => x.Categories,
                   opt => opt.MapFrom(q => q.CategoryNews.Select(x => x.Category)))

                  .ForMember(x => x.Comments,
                   opt => opt.MapFrom(q => q.Comments));
            CreateMap<CommentViewModelDTO, Comment>().ReverseMap()
                .ForMember(x => x.Name,
                opt => opt.MapFrom(q => q.User.Name))
                  .ForMember(x => x.Family,
                opt => opt.MapFrom(q => q.User.Family))
                    .ForMember(x => x.CreatedDate,
                opt => opt.MapFrom(q => q.CreatedDate.ToShamsi()));

            CreateMap<NewsSaveDTO, News>().ReverseMap()
                .ForMember(x => x.Poster,
                    opt => opt.MapFrom(q => $"http://localhost:5000/news/image/{q.Poster}"))
                .ForMember(x => x.CategoriesId,
                    opt => opt.MapFrom(q => q.CategoryNews.Select(z => z.CategoryId).ToList()))
                .ForMember(x => x.TagsId,
                    opt => opt.MapFrom(q => q.Tags.Select(z => z.Id).ToList()));
        }
    }
}