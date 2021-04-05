using System.Collections.Generic;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;

namespace HeshmastNews.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int Id);
        Category AddCategory(CategoryCreationDTO category);
        Category UpdateCategory(int categoryId,CategoryCreationDTO category);
      int DeleteCategory(int id);
        
    }
}