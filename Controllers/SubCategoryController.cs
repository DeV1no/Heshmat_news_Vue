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
    [ApiController]
    [Route("/api/SubCategory")]
    public class SubCategoryController : CustomBaseController
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public SubCategoryController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoriesDTO>>> Get()
        {
            return await Get<SubCategory, SubCategoriesDTO>();
        }

        [HttpGet("{id}", Name = "GetSubCat")]
        public async Task<ActionResult<SubCategoryDetailDTO>> Get(int id)
        {
            var subCategory = await _context.SubCategories
                .Include(x => x.SubToCat).ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return _mapper.Map<SubCategoryDetailDTO>(subCategory);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubCategoryCreationDTO subCategoryCreationDto)
        {
            var SubCategory = _mapper.Map<SubCategory>(subCategoryCreationDto);
            _context.Add(SubCategory);
            await _context.SaveChangesAsync();
            var categoryDTO = _mapper.Map<SubCategory>(SubCategory);
            return new CreatedAtRouteResult("GetSubCat", new {id = SubCategory.Id}, categoryDTO);
        }

        [HttpPut("{id}", Name = "putSubCategory")]
        public async Task<ActionResult> Put(int id, [FromBody] SubCategoryCreationDTO subCategoryCreationDto)
        {
            return await Put<SubCategoryCreationDTO, SubCategory>(id, subCategoryCreationDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<SubCategory>(id);
        }
    }
}