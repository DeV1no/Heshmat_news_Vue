using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dadachMovie.DTOs;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HeshmastNews.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /*CreateMap<Category, CategoriesDTO>().ReverseMap();
            CreateMap<CategoryCreationDTO, Category>();
            //comment map 
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<CommentCreationDTO, Comment>();
            //    CreateMap<SubCategory, SubCategoriesDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoriesDTO>().ReverseMap();
            CreateMap<SubCategoryCreationDTO, SubCategory>();
            CreateMap<SubCategory, SubCategoryDetailDTO>().ConvertUsing((entitiy, dto, context) =>
                new SubCategoryDetailDTO
                {
                    Id = entitiy.Id,
                    Name = entitiy.Name,
                    Category = entitiy.SubToCat.Select(c => c.Category)
                        .Select(c => context.Mapper.Map<CategoriesDTO>(c))
                        .ToList()
                });
            /*.ForMember(x => x.Category,
                 options => options.MapFrom(MapSubToCat));#1#

            CreateMap<CategoryCreationDTO, Category>()
                .ForMember(x => x.SubToCat, options
                    => options.MapFrom(MapSubToCats));

            CreateMap<News, NewsDTO>().ReverseMap();
            CreateMap<NewsCreationDTO, News>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.CategoryNews, options =>
                    options.MapFrom(MapNewsCategores));
            reateMap<News, NewsDetailDTO>()
                .ForMember(x => x.Categories, options
                    => options.MapFrom(MapNewsCategory))
                .ForMember(x => x.Comment, options =>
                    options.MapFrom(MapNewsComment));
            CreateMap<News, NewsPatchDTO>();
            CreateMap<IdentityUser, UserDTO>()
                .ForMember(x => x.EmailAddress, options => options.MapFrom(x => x.Email))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.Id));
        }

        private List<CategoriesDTO> MapSubToCat(SubCategory subCategory, SubCategoryDetailDTO subCategoryDetailDto)
        {
            var result = new List<CategoriesDTO>();
            foreach (var sTc in subCategory.SubToCat)
            {
                result.Add(new CategoriesDTO() {Id = sTc.CategoryId, Name = sTc.Category.Name});
            }

            return result;
        }


        private List<SubToCat> MapSubToCats(CategoryCreationDTO categoryCreationDto, Category category)
        {
            var result = new List<SubToCat>();
            foreach (var id in categoryCreationDto.CategoryId)
            {
                result.Add(new SubToCat() {SubCategoryId = id});
            }

            return result;
        }

        private List<CategoriesDTO> MapNewsCategory(News news, NewsDetailDTO newsDetailDto)
        {
            var result = new List<CategoriesDTO>();
            foreach (var categorynews in news.CategoryNews)
            {
                result.Add(new CategoriesDTO() {Id = categorynews.CategoryId, Name = categorynews.Category.Name});
            }

            return result;
        }

        private List<CategoryNews> MapNewsCategores(NewsCreationDTO newsCreationDto, News news)
        {
            var result = new List<CategoryNews>();
            foreach (var category in newsCreationDto.Categories)
            {
                result.Add(new CategoryNews() {CategoryId = category.Id, Character = category.Name});
            }

            return result;
        }

        /*private List<CommentDTO> MapNewsComment(News news, NewsCreationDTO newsCreationDto)
        {
            var result = new List<CommentDTO>();
            foreach (var nTc in news.ComentNews)
            {
                result.Add(new CommentDTO()
                {
                    Id = nTc.CommentId,
                    Content = nTc.Comment.Content,
                    rate = nTc.Comment.rate,
                    DateCreated = nTc.Comment.DateCreated
                });
            }

            return result;
        }
        #1#

        private List<CommentDTO> MapNewsComment(News news, NewsDetailDTO newsDetailDto)
        {
            var result = new List<CommentDTO>();
            foreach (var nTc in news.ComentNews)
            {
                result.Add(new CommentDTO()
                {
                    Id = nTc.CommentId,
                    Content = nTc.Comment.Content,
                    rate = nTc.Comment.rate,
                    DateCreated = nTc.Comment.DateCreated
                });
            }

            return result;
        }

        /*private List<ComentNews> MapNewsComment(CommentCreationDTO commentCreationDto, Comment comment)
        {
            var result = new List<ComentNews>();

            foreach (var id in commentCreationDto.NewsId)
            {
                result.Add(new ComentNews() {NewsId = id});
            }

            return result;
        }#1#
    }*/
        }
    }
}