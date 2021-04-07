using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dadachMovie.DTOs;
using HeshmastNews.Convertor;
using HeshmastNews.Data;
using HeshmastNews.Entities;
using HeshmastNews.Generator;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Services
{
    public class NewsService : INewsService
    {
        private ApplicationDbContext _context;

        public NewsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<NewsViewModelDTO> GetAllNews()
        {
            IQueryable<News> result = _context.News;
            var query = result
                .Select(n => new NewsViewModelDTO()
                {
                    NewsId = n.NewsId,
                    NewsTitle = n.NewsTitle,
                    NewsBody = n.NewsBody,
                    Poster =$"http://localhost:5000/news/image/{n.Poster}",
                    Tags = n.Tags,
                    Category = n.CategoryId,
                    CreatedDate = n.CreatedDate.ToShamsi(),
                }).ToList();
            return new List<NewsViewModelDTO>(query);
        }

        public News GetNewsById(int newsId)
        {
            var news = _context.News
                .Single(n => n.NewsId == newsId);
            news.Category = _context.Categories
                .Single(c => c.CategoryId==news.CategoryId);
            return news;
        }

        public News AddNews(NewsCreationDTO news)
        {
            // IMG
            var poster = NameGenerator.GenerateUniqCode() + Path.GetExtension(news.Poster.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/news/image",
                poster);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                news.Poster.CopyTo(stream);
            }

            var NewsCreationDTO = new News()
            {
                NewsTitle = news.NewsTitle,
                NewsBody = news.NewsBody,
                Tags = news.Tags,
                Poster =  poster,
                CategoryId = news.CategoryId,
                SubGroup = news.SubGroup
            };
            _context.Add(NewsCreationDTO);
            _context.SaveChanges();
            return NewsCreationDTO;
        }

        public News UpdateNews(int newwsId, NewsCreationDTO news)
        {
           news.UpdateDate = DateTime.Now;
           var poster = "";
           if (news.Poster != null)
           {
              
                   string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/image",
                       news.Poster.FileName);
                   if (File.Exists(deleteimagePath))
                   {
                       File.Delete(deleteimagePath);
                   }
                   

                   poster = NameGenerator.GenerateUniqCode() + Path.GetExtension(news.Poster.FileName);
                   string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/news/image",
                       poster);

               using (var stream = new FileStream(imagePath, FileMode.Create))
               {
                   news.Poster.CopyTo(stream);
               }

           } 
           var NewsCreationDTO = new News()
           {
               NewsTitle = news.NewsTitle,
               NewsBody = news.NewsBody,
               Tags = news.Tags,
               Poster =  poster,
               CategoryId = news.CategoryId,
               SubGroup = news.SubGroup
           };
           _context.Add(NewsCreationDTO);
           _context.SaveChanges();
           return NewsCreationDTO;
        
        }

        public int DeleteNews(int newsId)
        {
            var news = _context.News.Find(newsId);
            _context.News.Remove(news);
            _context.SaveChanges();
            return newsId;
        }
    }
}