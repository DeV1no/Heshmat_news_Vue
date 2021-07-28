using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.DTOs.Category;
using HeshmastNews.Data;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;
using HeshmastNews.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController
    {
        private ApplicationDbContext _context;
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, ApplicationDbContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }


        [HttpGet(Name = "getCategories")]
        public List<CategoryVewModelDTO> Get()
            => _categoryService.GetAllCategories();


        [HttpGet("getParentCategories")]
        public List<CategoryVewModelDTO> GetParentCategories()
            => _categoryService.GetAllParrentCategory();

        [HttpGet("getSubCategories")]
        public Task<List<CategoryVewModelDTO>> GetSubCategories()
            => _categoryService.GetAllSubCategory();




        [HttpGet("getSubCategoriesWithCount/{skip:int}/{take:int}")]
        public Task<List<SubCategoryWithCountDTO>> SubCategoryWithCount(int skip, int take)
           => _categoryService.SubCategoryWithCount(skip, take);


        [HttpGet("{categoryId:int}", Name = "getCategory")]
        public CategoryVewModelDTO Get(int categoryId)
            => _categoryService.GetCategoryById(categoryId);


        [HttpPost]
        [Authorize]
        public int Post([FromBody] CategoryCreateDTO model)
            => _categoryService.AddCategory(model);


        [HttpPut(Name = "putCategories")]
        public int Put([FromBody] CategoryUpdateDTO model)
            => _categoryService.UpdateCategory(model);


        [HttpDelete("{id}", Name = "deleteCategoires")]
        public int Delete(int id)
            => _categoryService.DeleteCategory(id);
    }
}