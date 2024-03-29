using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.DTOs.News;
using Gridify;
using HeshmastNews.DTOs;
using HeshmastNews.DTOs.News;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.Services
{
    public interface INewsService
    {
        List<NewsListViewModleDTO> GetNewsList();
        List<NewsHomeViewModelDTO> GetNewsHomeList(int take, int skip);
        List<NewsHomeViewModelDTO> GetNewsByCategoryId(int take, int skip, int categoryId);
        Task<List<NewsHomeViewModelDTO>> GetNewsByTagIdList(int take, int skip, int tagId);
        List<NewsHomeViewModelDTO> GetNewsChoseClerkList(int take, int skip);
        Task<NewsSingleDTO> GetSingleNews(int newsId);
        Task<int> GetTotallNewsCount();
        NewsSaveDTO GetNewsSave(int newsId);
        News GetNewsById(int newwsId);
        int AddNews(NewsCreationDTO news, string userId);
        int UpdateNews(int newsId, NewsCreationDTO model);
        bool DeleteNews(int newsId);
       Task<bool> AddRateNews(AddNewsRateDTO model,int userId);


    }
}