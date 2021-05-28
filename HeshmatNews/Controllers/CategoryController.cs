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
        public List<Category> Get()
        {
            return _categoryService.GetAllCategories();
        }
        
        [HttpGet("getSubCategories")]
        public List<Category> GetCategories()
        {
            return _categoryService.GetAllSubCategory();
        }

      
        [HttpGet("{categoryId:int}", Name = "getCategory")]
        public Category Get(int categoryId)
        {
            return _categoryService.GetCategoryById(categoryId);
        }

        [HttpPost]
        [Authorize]
        public Category Post([FromBody] CategoryCreationDTO category)
        {
            return _categoryService.AddCategory(category);
        }

        [HttpPut("{categoryId}", Name = "putCategories")]
        public Category Put(int categoryId, [FromBody] CategoryCreationDTO category)
        {
            return _categoryService.UpdateCategory(categoryId,category);
        }

        [HttpDelete("{id}", Name = "deleteCategoires")]
        public int Delete(int id)
        {
            return _categoryService.DeleteCategory(id);
        }
    }
}