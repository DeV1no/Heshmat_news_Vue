using dadachMovie.DTOs.Admin;
using dadachMovie.Services.Contracts;
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
    }
}
