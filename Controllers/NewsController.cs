using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.DTOs;
using Gridify;
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
    public class NewsController
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private readonly string containerName = "news";

        public NewsController(ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService)

        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        [Produces(typeof(Paging<News>))]
        public Paging<News> Get([FromQuery] GridifyQuery gQuery)
        {
            return _context.News.Gridify(gQuery);
        }

        [HttpGet("{id}", Name = "getNews")]
        public async Task<ActionResult<NewsDetailDTO>> Get(int id)
        {
            var news = await _context.News
                .Include(n => n.CategoryNews)
                .ThenInclude(n => n.Category)
                .FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                // return NoContentResult;
            }

            return _mapper.Map<NewsDetailDTO>(news);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] NewsCreationDTO newsCreationDto)
        {
            var news = _mapper.Map<News>(newsCreationDto);
            if (newsCreationDto.Poster != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await newsCreationDto.Poster.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(newsCreationDto.Poster.FileName);
                    news.Poster =
                        await _fileStorageService.SaveFile(content, extension, containerName,
                            newsCreationDto.Poster.ContentType);
                }
            }

             AnnotateActorsOrder(news);
            _context.Add(news);
            await _context.SaveChangesAsync();
            var newsDTO = _mapper.Map<NewsDTO>(news);
            return new CreatedAtRouteResult("getNews", new {id = news.Id}, newsDTO);
        }

        private static void AnnotateActorsOrder(News news)
        {
            if (news.CategoryNews != null)
            {
                for (int i = 0; i < news.CategoryNews.Count; i++)
                {
                    news.CategoryNews[i].Order = i;
                }
            }
        }
    }
}