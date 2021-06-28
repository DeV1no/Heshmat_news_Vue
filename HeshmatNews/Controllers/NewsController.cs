using System;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private ApplicationDbContext _context;

        private readonly IFileStorageService _fileStorageService;
        private INewsService _newsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NewsController(
            ApplicationDbContext context, IFileStorageService fileStorageService,
            INewsService newsService, IHttpContextAccessor httpContextAccessor)

        {
            _context = context;
            _fileStorageService = fileStorageService;
            _newsService = newsService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("NewsList")]
        public List<NewsListViewModleDTO> GetNewsList()
            => _newsService.GetNewsList();

        [HttpGet("NewsHomeList")]
        public List<NewsHomeViewModelDTO> GetNewsHomeList()
            => _newsService.GetNewsHomeList();

        [HttpGet("{newsId}", Name = "getNews")]
        public News Get(int newsId)
        {
            return _newsService.GetNewsById(newsId);
        }

        [HttpGet("SaveDTO/{newsId:int}")]
        public NewsSaveDTO GetNewsSaveDTO(int newsId)
            => _newsService.GetNewsSave(newsId);

        [HttpPost("AddNews")]
        [Authorize]
        public int Post([FromForm] NewsCreationDTO model)
            => _newsService.AddNews(model, _httpContextAccessor.HttpContext.User.Identity.Name);


        [HttpPut("{id}")]
        public Task<ActionResult> Put(int id, [FromForm] NewsCreationDTO newsCreationDto)
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
        public bool Delete(int newsId)
            => _newsService.DeleteNews(newsId);
    }
}