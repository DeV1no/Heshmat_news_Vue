using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HeshmastNews.Data;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "getCategories")]
        public async Task<ActionResult<List<CategoriesDTO>>> Get()
        {
            return await Get<Category, CategoriesDTO>();
        }

        [HttpGet("{Id:int}", Name = "getCategory")]
        public async Task<ActionResult<CategoriesDTO>> Get(int id)
        {
            return await Get<Category, CategoriesDTO>(id);
        }

        [HttpPost]
        //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Post([FromBody] CategoryCreationDTO categoryCreationDto)
        {
            var category = _mapper.Map<Category>(categoryCreationDto);
        
            _context.Add(category);
            await _context.SaveChangesAsync();
            var categoryDTO = _mapper.Map<CategoriesDTO>(category);
            return new CreatedAtRouteResult("getCategory", new {id = category.Id}, categoryDTO);
        }

        [HttpPut("{id}", Name = "putCategories")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryCreationDTO categoryCreationDto)
        {
            return await Put<CategoryCreationDTO, Category>(id, categoryCreationDto);
        }

        [HttpDelete("{id}", Name = "deleteCategoires")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Category>(id);
        }
    }
}