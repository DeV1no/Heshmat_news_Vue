using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs.Category;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;

namespace HeshmastNews.Services
{
    public interface ICategoryService
    {
        List<CategoryVewModelDTO> GetAllCategories();
        List<CategoryVewModelDTO> GetAllParrentCategory();
        Task<List<CategoryVewModelDTO>> GetAllSubCategory();
        Task<List<SubCategoryWithCountDTO>> SubCategoryWithCount(int skip, int take);
        CategoryVewModelDTO GetCategoryById(int Id);
        int AddCategory(CategoryCreateDTO model);
        int UpdateCategory(CategoryUpdateDTO model);
        int DeleteCategory(int id);
    }
}