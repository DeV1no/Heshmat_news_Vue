using System.Collections.Generic;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;

namespace HeshmastNews.Services
{
    public interface ICategoryService
    {
        List<CategoryVewModelDTO> GetAllCategories();
        List<CategoryVewModelDTO> GetAllParrentCategory();
        List<CategoryVewModelDTO> GetAllSubCategory();
        CategoryVewModelDTO GetCategoryById(int Id);
        int AddCategory(CategoryCreateDTO model);
        int UpdateCategory(CategoryUpdateDTO model);
        int DeleteCategory(int id);
    }
}