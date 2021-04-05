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
        private readonly string containerName = "news";
        private INewsService _newsService;
        public NewsController(
            ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService, INewsService newsService)

        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
            _newsService = newsService;
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
           
          

            return null;
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
            return null;
            //new CreatedAtRouteResult("getNews", new {id = news.Id}, newsDTO);
        }

        private static void AnnotateActorsOrder(News news)
        {
          
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] NewsCreationDTO newsCreationDto)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
          
            return null;
        }
        [HttpPost("AddUserComment")]
        /*[Authorize]
        [ValidateModel]*/
        public async Task<ActionResult> AddComment([FromBody] CommentCreationDTO commentCreationDTO)
        {
            var result = await _newsService.AddUserCommentAsync(commentCreationDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpDelete("RemoveUserComment/{id:int}")]
        /*[Authorize(Roles = "Admin")]
        [ValidateModel]*/
        public async Task<ActionResult> RemoveComment(int id)
        {
            var result = await _newsService.DeleteUserCommentAsync(id);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }
    }
}