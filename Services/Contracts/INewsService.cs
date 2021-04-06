using System.Collections.Generic;
using dadachMovie.DTOs;
using HeshmastNews.Entities;

namespace HeshmastNews.Services
{
    public interface INewsService
    {
        List<NewsViewModelDTO> GetAllNews();
        News GetNewsById(int newwsId);
        News AddNews(NewsCreationDTO news);
        News UpdateNews(int newsId, NewsCreationDTO news);
        int DeleteNews(int newsId);
    }
}