using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.DTOs;
using HeshmastNews.Data;
using HeshmastNews.DTOs;
using HeshmastNews.DTOs.News;
using HeshmastNews.Entities;
using HeshmastNews.Generator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Services
{
    public class NewsService : INewsService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public NewsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public NewsService()
        {
        }


        public List<NewsListViewModleDTO> GetNewsList()
        {
            var newsDbList = _context.News.Include(x => x.User).ToList();
            var newsList = new List<NewsListViewModleDTO>();
            foreach (var item in newsDbList)
            {
                newsList.Add(_mapper.Map<NewsListViewModleDTO>(item));
            }

            return newsList;
        }

        public List<NewsHomeViewModelDTO> GetNewsHomeList(int take, int skip)
        {
            var newsDbList = _context.News.Include(x => x.User)
                .OrderByDescending(x => x.CreatedDate)
                .Skip(skip).Take(take).ToList();
            var newsList = new List<NewsHomeViewModelDTO>();
            foreach (var item in newsDbList)
            {
                newsList.Add(_mapper.Map<NewsHomeViewModelDTO>(item));
            }

            return newsList;
        }

        public List<NewsHomeViewModelDTO> GetNewsChoseClerkList(int take, int skip)
        {
            var newsDbList = _context.News.Include(x => x.User)
                .Where(x => x.isChoseClerck)
                .OrderBy(x => x.NewsId)
                .Skip(skip).Take(take).ToList();
            var newsList = new List<NewsHomeViewModelDTO>();
            foreach (var item in newsDbList)
            {
                newsList.Add(_mapper.Map<NewsHomeViewModelDTO>(item));
            }

            return newsList;
        }


        public NewsSaveDTO GetNewsSave(int newsId)
        {
            var newsDb = _context.News
                .Include(x => x.CategoryNews).ThenInclude(x => x.Category).Include(x => x.Tags)
                .FirstOrDefault(x => x.NewsId == newsId);
            return _mapper.Map<NewsSaveDTO>(newsDb);
        }

        public News GetNewsById(int newwsId)
        {
            throw new NotImplementedException();
        }

        public int AddNews(NewsCreationDTO model, string userId)
        {
            // IMG
            var poster = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.Poster.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/news/image",
                poster);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                model.Poster.CopyTo(stream);
            }


            var taglist = new List<Tag>();
            foreach (var id in model.TagsId)
            {
                taglist.Add(_context.Tags.FirstOrDefault(x => x.Id == id));
            }

            var categoryList = new List<Category>();
            foreach (var id in model.CategoriesId)
            {
                categoryList.Add(_context.Categories.FirstOrDefault(x => x.CategoryId == id));
            }

            var newsDb = new News()
            {
                NewsTitle = model.NewsTitle,
                NewsBody = model.NewsBody,
                Poster = poster,
                User = _context.Users.FirstOrDefault(x => x.Id.ToString() == userId),
                Tags = taglist,
                //  CategoryNews = categoryList,
            
                isChoseClerck = model.isChoseClerck,
                Source = model.Source
            };
            _context.Add(newsDb);
            _context.SaveChanges();
            return newsDb.NewsId;
        }

        public int UpdateNews(int newsId, NewsCreationDTO model)
        {
            var newsDb = _context.News.FirstOrDefault(x => x.NewsId == newsId);
            if (newsDb == null)
                return -1;
            // IMG
            string poster;
            if (model.Poster != null)
            {
                poster = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.Poster.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/news/image",
                    poster);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.Poster.CopyTo(stream);
                }
            }
            else
            {
                poster = newsDb.Poster;
            }

            var taglist = new List<Tag>();
            foreach (var id in model.TagsId)
            {
                taglist.Add(_context.Tags.FirstOrDefault(x => x.Id == id));
            }

            var categoryList = new List<Category>();
            foreach (var id in model.CategoriesId)
            {
                categoryList.Add(_context.Categories.FirstOrDefault(x => x.CategoryId == id));
            }

            var news = new News()
            {
                NewsId = newsId,
                NewsTitle = model.NewsTitle,
                NewsBody = model.NewsBody,
                Poster = poster,
                User = newsDb.User,
                Tags = taglist,

                UpdateTime = DateTime.Now
            };

            _context.News.Update(news);
            _context.SaveChanges();
            return news.NewsId;
        }

        public bool DeleteNews(int newsId)
        {
            var newsDb = _context.News
                .FirstOrDefault(x => x.NewsId == newsId);
            if (newsDb == null)
                return false;
            _context.Remove(newsDb);
            _context.SaveChanges();
            return true;
        }

        public async Task<NewsSingleDTO> GetSingleNews(int newsId)
        {
            var newsDb = await _context.News
                .Include(x => x.CategoryNews).ThenInclude(x => x.Category).Include(x => x.User)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.NewsId == newsId);

            return _mapper.Map<NewsSingleDTO>(newsDb);
        }

        public async Task<int> GetTotallNewsCount()
            => await _context.News.CountAsync();

        public async Task<List<NewsHomeViewModelDTO>> GetNewsByTagIdList(int take, int skip, int tagId)
        {
            var newsDbList = _context.News
                 .Include(x => x.User)
                 .Include(x => x.Tags.Where(q => q.Id == tagId))
                 .OrderByDescending(x => x.CreatedDate)
                 .Skip(skip).Take(take).ToList();
            var newsList = new List<NewsHomeViewModelDTO>();
            foreach (var item in newsDbList)
            {
                newsList.Add(_mapper.Map<NewsHomeViewModelDTO>(item));
            }

            return newsList;
        }



        public List<NewsHomeViewModelDTO> GetNewsByCategoryId(int take, int skip, int categoryId)
        {
            var newsDbList = _context.News
                .Include(x => x.User)
                .Include(x => x.CategoryNews.Where(x => x.CategoryId == categoryId))
                .OrderByDescending(x => x.CreatedDate)
                .Skip(skip).Take(take).ToList();
            var newsList = new List<NewsHomeViewModelDTO>();
            foreach (var item in newsDbList)
            {
                newsList.Add(_mapper.Map<NewsHomeViewModelDTO>(item));
            }

            return newsList;
        }
    }
}