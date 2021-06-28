using System.Collections.Generic;
using dadachMovie.DTOs;
using Gridify;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.Services
{
    public interface INewsService
    {
        List<NewsListViewModleDTO> GetNewsList();
        List<NewsHomeViewModelDTO> GetNewsHomeList();
        NewsSaveDTO GetNewsSave(int newsId);
        News GetNewsById(int newwsId);
        int AddNews(NewsCreationDTO news, string userId);
        int UpdateNews(NewsUpdateDTO model);
       bool DeleteNews(int newsId);
    }
}