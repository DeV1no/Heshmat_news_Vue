using System.Collections.Generic;
using System.Linq;
using HeshmastNews.Data;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;

namespace HeshmastNews.Services
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }


        public Category AddCategory(CategoryCreationDTO category)
        {
            var CategoryCreationDTO = new Category()
            {
                CateGoryName = category.CateGoryName,
                ParentId = category.ParentId
            };
            _context.Categories.Add(CategoryCreationDTO);
            _context.SaveChanges();
            return CategoryCreationDTO;
        }

        public Category UpdateCategory(int categoryId, CategoryCreationDTO category)
        {
            var categoryDb = GetCategoryById(categoryId);
            categoryDb.CateGoryName = category.CateGoryName;
            category.ParentId = category.ParentId;
            _context.Categories.Update(categoryDb);
            _context.SaveChanges();
            return categoryDb;
        }

        public int DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return id;
        }
    }
}