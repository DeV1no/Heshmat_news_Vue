using dadachMovie.DTOs.Admin;
using dadachMovie.Services.Contracts;
using HeshmastNews.Convertor;
using HeshmastNews.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.Services
{
    public class AdminPageService : IAdminPageService
    {
        private ApplicationDbContext _context;
        public AdminPageService(ApplicationDbContext context)
        {
            _context = context;
        }
        public AdminPageItemCountsDTO GetAdminPageItemCounts()
        =>
           new AdminPageItemCountsDTO
           {
               CategoryCount = _context.Categories.Count(),
               NewsCount = _context.News.Count(),
               RolesCount = _context.Roles.Count(),
               UserCount = _context.Users.Count(),
           };

        public List<UserRegisterByDateCountDTO> GetUserRegisterByDateCountDTO()
        {
            var queryList = (from user in _context.Users
                             select new UserRegisterByDateCountDTO
                             {
                                 RegisterTimeString = user.RegisterDate.ToShamsi(),
                                 UserCount = 0
                             }).ToList();
            var UserRegisterByDateCountList = new List<UserRegisterByDateCountDTO>();
            foreach (var item in queryList.GroupBy(x=>x.RegisterTimeString).ToList())
            {
                var query = new UserRegisterByDateCountDTO
                {
                    UserCount = item.Count(),
                    RegisterTimeString = item.First().RegisterTimeString
                };
                UserRegisterByDateCountList.Add(query);
            }
            return UserRegisterByDateCountList;
        }

    }
}
