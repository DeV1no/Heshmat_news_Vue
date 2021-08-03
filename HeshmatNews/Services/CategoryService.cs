using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.DTOs.Category;
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


        public async Task<List<CategoryVewModelDTO>> GetAllSubCategory()
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

        public async Task<List<SubCategoryWithCountDTO>> SubCategoryWithCount(int skip, int take)
        {
            /*var query = await _context.CategoryNews.GroupBy(x => x.Category)
                .Select(x => new SubCategoryWithCountDTO
                {
                    CategoryId = x.Key.CategoryId,
                    CateGoryName = x.Key.CateGoryName,
                    UseCount = x.Count()
                }).AsNoTracking().ToListAsync();*/

            /*var query = await (from category in _context.Categories
                    from categoryNews in category.CategoryNews
                    group categoryNews by categoryNews.Category
                    into gpNews
                    select new SubCategoryWithCountDTO
                    {
                        CategoryId = gpNews.Key.CategoryId,
                        CateGoryName = gpNews.Key.CateGoryName,
                        UseCount = gpNews.Count()
                    }
                ).AsNoTracking().ToListAsync();*/
            var query = await (from oneNews in _context.CategoryNews
                    select new SubCategoryWithCountDTO
                    {
                        CategoryId = oneNews.CategoryId,
                        CateGoryName = oneNews.Category.CateGoryName,
                        UseCount = 1
                    }
                ).AsNoTracking().ToListAsync();
            var finalList = new List<SubCategoryWithCountDTO>();
            foreach (var item in query.GroupBy(x => x.CategoryId).ToList())
            {
                finalList.Add(new SubCategoryWithCountDTO
                {
                    CategoryId = item.Key,
                    CateGoryName = item.First().CateGoryName,
                    UseCount = item.Count()
                });
            }

            return finalList;
        }

        /*await (from oneNews in _context.CategoryNews
            group oneNews by oneNews.Category
            into gpNews
            select new SubCategoryWithCountDTO
            {
                CategoryId = gpNews.Key.CategoryId,
                CateGoryName = gpNews.Key.CateGoryName,
                UseCount = gpNews.Count()
            }
        ).AsNoTracking().ToListAsync();*/

        /* var subCategoryList = await _context.Categories
             .Where(x => x.ParentId != null).OrderBy(x => x.CategoryId)
             .Skip(skip).Take(take).ToListAsync();
         var SubCategoryWithCount = new List<SubCategoryWithCountDTO>();

         var news = _context.News.Include(x => x.Category);
         foreach (var item in subCategoryList)
         {

             var categoryUse = news.SelectMany(x => x.Category.Where(x => x.CategoryId == item.CategoryId)).CountAsync();
             var preSubCategory = new SubCategoryWithCountDTO
             {
                 CategoryId = item.CategoryId,
                 CateGoryName = item.CateGoryName,
                 UseCount = await categoryUse
             };
             SubCategoryWithCount.Add(preSubCategory);
         }

         return SubCategoryWithCount;*/


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