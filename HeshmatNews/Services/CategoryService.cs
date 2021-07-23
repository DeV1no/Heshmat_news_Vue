using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HeshmastNews.Data;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Services
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        public List<CategoryVewModelDTO> GetAllCategories()
        {
            var category = new List<CategoryVewModelDTO>();
            var categoryDb = _context.Categories.ToList();
            foreach (var item in categoryDb)
            {
                category.Add(_mapper.Map<CategoryVewModelDTO>(item));
            }

            return category;
        }

        public List<CategoryVewModelDTO> GetAllParrentCategory()
        {
            var category = new List<CategoryVewModelDTO>();
            var categoryDb = _context.Categories
                .Where(x => x.ParentId == null).ToList();
            foreach (var item in categoryDb)
            {
                category.Add(_mapper.Map<CategoryVewModelDTO>(item));
            }

            return category;
        }

        public List<CategoryVewModelDTO> GetAllSubCategory()
        {
            var subCategoriesDbList = _context.Categories
                .Where(x => x.ParentId != null).ToList();
            var parentCategoriesList = new List<CategoryVewModelDTO>();

            foreach (var item in subCategoriesDbList)
            {
                parentCategoriesList.Add(_mapper.Map<CategoryVewModelDTO>(item));
            }
            return parentCategoriesList;
        }


        public CategoryVewModelDTO GetCategoryById(int categoryId)
        {
            var categoryDb = _context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            return _mapper.Map<CategoryVewModelDTO>(categoryDb);
        }


        public int AddCategory(CategoryCreateDTO model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.CategoryId;
        }


        public int UpdateCategory(CategoryUpdateDTO model)
        {
            var isExisted = _context.Categories.Any(x => x.CategoryId == model.CategoryId);
            if (model.ParentId != null)
            {
                var isParentAExisted = _context.Categories.Any(x => x.ParentId == model.ParentId);
                if (!isParentAExisted)
                    return -1;
            }

            if (!isExisted)
                return -1;
            var category = _mapper.Map<Category>(model);
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category.CategoryId;
        }

        public int DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            var isChildExisted = false;
            if (category.ParentId == null)
                isChildExisted = _context.Categories.Any(x => x.ParentId == category.CategoryId);
            if (isChildExisted)
                return -2; // child categrory is existed
            if (category == null)
                return -1;
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return id;
        }
    }
}