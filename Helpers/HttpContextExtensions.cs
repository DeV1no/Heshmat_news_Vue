using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertPaginationParametesInResponse<T>
            (this HttpContext httpContext, IQueryable<T> queryable, int recordsPerPage)
        {
            if (httpContext==null)
            {
                throw new ArgumentException(nameof(httpContext));
            }

            double count = await queryable.CountAsync();
            double totalAmountPages = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("totalAmountPages" ,totalAmountPages.ToString());
        }
    }
}