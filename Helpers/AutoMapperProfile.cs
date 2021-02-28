using AutoMapper;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;

namespace HeshmastNews.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoriesDTO>().ReverseMap();
            CreateMap<CategoryCreationDTO, Category>();
        }
    }
}