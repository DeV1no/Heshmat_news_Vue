using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        {
            return _categoryService.GetAllCategories();
        }
        
        [HttpGet("getParentCategories")]
        public List<CategoryVewModelDTO> GetParentCategories()
        {
            return _categoryService.GetAllParrentCategory();
        }

      
        [HttpGet("{categoryId:int}", Name = "getCategory")]
        public CategoryVewModelDTO Get(int categoryId)
        {
            return _categoryService.GetCategoryById(categoryId);
        }

        [HttpPost]
        [Authorize]
        public int Post([FromBody] CategoryCreateDTO model)
        {
            return _categoryService.AddCategory(model);
        }

        [HttpPut( Name = "putCategories")]
        public int Put( [FromBody] CategoryUpdateDTO model)
        {
            return _categoryService.UpdateCategory(model);
        }

        [HttpDelete("{id}", Name = "deleteCategoires")]
        public int Delete(int id)
        {
            return _categoryService.DeleteCategory(id);
        }
    }
}