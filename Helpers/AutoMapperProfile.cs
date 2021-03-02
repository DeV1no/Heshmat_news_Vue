using System.Collections.Generic;
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
            //    CreateMap<SubCategory, SubCategoriesDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoriesDTO>().ReverseMap();
            CreateMap<SubCategoryCreationDTO, SubCategory>();
            CreateMap<SubCategory, SubCategoryDetailDTO>()
                .ForMember(x => x.Category,
                    options => options.MapFrom(MapSubToCat));

            CreateMap<CategoryCreationDTO, Category>()
                .ForMember(x => x.SubToCat, options
                    => options.MapFrom(MapSubToCats));

         
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


       
    }
}