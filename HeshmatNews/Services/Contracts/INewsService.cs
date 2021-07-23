using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using Gridify;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.Services
{
    public interface INewsService
    {
        List<NewsListViewModleDTO> GetNewsList();
        List<NewsHomeViewModelDTO> GetNewsHomeList(int take,int skip);
        NewsSaveDTO GetNewsSave(int newsId);
        News GetNewsById(int newwsId);
        int AddNews(NewsCreationDTO news, string userId);
        int UpdateNews(int newsId, NewsCreationDTO model);
        bool DeleteNews(int newsId);
    }
}