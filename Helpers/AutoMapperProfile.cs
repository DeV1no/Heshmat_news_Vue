using System.Collections.Generic;
using AutoMapper;
using dadachMovie.DTOs;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace HeshmastNews.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoriesDTO>().ReverseMap();
            CreateMap<CategoryCreationDTO, Category>();
            //    CreateMap<SubCategory, SubCategoriesDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoriesDTO>().ReverseMap();
            CreateMap<SubCategoryCreationDTO, SubCategory>();
            CreateMap<SubCategory, SubCategoryDetailDTO>()
                .ForMember(x => x.Category,
                    options => options.MapFrom(MapSubToCat));

            CreateMap<CategoryCreationDTO, Category>()
                .ForMember(x => x.SubToCat, options
                    => options.MapFrom(MapSubToCats));

            CreateMap<News, NewsDTO>().ReverseMap();
            CreateMap<NewsCreationDTO, News>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.CategoryNews, options =>
                    options.MapFrom(MapNewsCategores));
            CreateMap<News, NewsDetailDTO>()
                .ForMember(x => x.Categories, options
                    => options.MapFrom(MapNewsCategory));
            CreateMap<News, NewsPatchDTO>();
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
                result.Add(new CategoryNews() {CategoryId =category.Id,Character = category.Name});
            }

            return result;
        }
        /*private List<SubToCat> MapSubToCats(CategoryCreationDTO categoryCreationDto, Category category)
        {
            var result = new List<SubToCat>();
            foreach (var id in categoryCreationDto.CategoryId)
            {
                result.Add(new SubToCat() {SubCategoryId = id});
            }

            return result;
        }*/
        /*private List<MovieGenres> MapMoviesGenres(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MovieGenres>();
            foreach (var id in movieCreationDTO.GenresIds)
            {
                result.Add(new MovieGenres() {GenresId = id});
            }

            return result;
        }*/

        
        
    }
}