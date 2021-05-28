using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.DTOs;
using Gridify;
using HeshmastNews.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs;
using HeshmastNews.Entities;
using HeshmastNews.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private INewsService _newsService;

        public NewsController(
            ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService,
            INewsService newsService)

        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
            _newsService = newsService;
        }

        [HttpGet]
        [Produces(typeof(Paging<News>))]
        public IActionResult Get()
        {
            return Ok (_newsService.GetAllNews());
           
        }

        [HttpGet("{newsId}", Name = "getNews")]
        public News Get(int newsId)
        {
            return _newsService.GetNewsById(newsId);;
        }

        [HttpPost]
        public News Post([FromForm] NewsCreationDTO newsCreationDto)
        {
            return _newsService.AddNews(newsCreationDto);
        }

      

        [HttpPut("{id}")]
        public  Task<ActionResult> Put(int id, [FromForm] NewsCreationDTO newsCreationDto)
        {
            // var newsDB = await _context.News.FirstOrDefaultAsync;


            /*newsDB = _mapper.Map(newsCreationDto, newsDB);
            if (newsCreationDto.Poster != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await newsCreationDto.Poster.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(newsCreationDto.Poster.FileName);
                    /*newsCreationDto.Poster =
                        await _fileStorageService.EditFile(content, extension, containerName, newsDB.Poster,
                            newsCreationDto.Poster.ContentType);#1#
                }
            }*/

            //       await _context.SaveChangesAsync();
            return null;
        }

        [HttpDelete("{newsId}")]
        public int Delete(int newsId)
        {
            return _newsService.DeleteNews(newsId);
        }
    }
}