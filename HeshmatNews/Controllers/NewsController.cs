using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.DTOs;
using dadachMovie.DTOs.News;
using Gridify;
using HeshmastNews.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs;
using HeshmastNews.DTOs.News;
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

        [HttpGet("NewsHomeList/{take:int}/{skip:int}")]
        public List<NewsHomeViewModelDTO> GetNewsHomeList(int take, int skip)
            => _newsService.GetNewsHomeList(take, skip);

        [HttpGet("NewsChoseClerkList/{take:int}/{skip:int}")]
        public List<NewsHomeViewModelDTO> GetNewsChoseClerkList(int take, int skip)
            => _newsService.GetNewsChoseClerkList(take, skip);

        [HttpGet("NewsByTagId/{take:int}/{skip:int}/{tagId:int}")]
        public Task<List<NewsHomeViewModelDTO>> GetNewsByTagIdList(int take, int skip, int tagId)
           => _newsService.GetNewsByTagIdList(take, skip, tagId);

        [HttpGet("NewsByCategoryId/{take:int}/{skip:int}/{categoryId:int}")]
        public async Task<List<NewsHomeViewModelDTO>> GetNewsByCategoryIdList(int take, int skip, int categoryId)
          => _newsService.GetNewsByCategoryId(take, skip, categoryId);

        [HttpGet("NewsSingle/{newsId:int}")]
        public Task<NewsSingleDTO> GetSingleNess(int newsId)
            => _newsService.GetSingleNews(newsId);
        [HttpGet("Count")]
        public Task<int> NewsTotallCount()
            => _newsService.GetTotallNewsCount();

        [HttpGet("{newsId}", Name = "getNews")]
        public News Get(int newsId)
            => _newsService.GetNewsById(newsId);


        [HttpGet("SaveDTO/{newsId:int}")]
        public NewsSaveDTO GetNewsSaveDTO(int newsId)
            => _newsService.GetNewsSave(newsId);

        [HttpPost("AddNews")]
        [Authorize]
        public int Post([FromForm] NewsCreationDTO model)
            => _newsService.AddNews(model, _httpContextAccessor.HttpContext.User.Identity.Name);


        [HttpPut("{id}")]
        [Authorize]
        public int Put(int id, [FromForm] NewsCreationDTO model)
            => _newsService.UpdateNews(id, model);
        [HttpPut("/addRateNews")]
        [Authorize]

        public async Task<bool> AddNewsRate(AddNewsRateDTO model)
            => await _newsService.AddRateNews(model,
                Convert.ToInt32(_httpContextAccessor.HttpContext.User.Identity.Name));


        [HttpDelete("{newsId}")]
        public bool Delete(int newsId)
            => _newsService.DeleteNews(newsId);
    }
}