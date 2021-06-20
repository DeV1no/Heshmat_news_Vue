using System.Linq;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeshmastNews.Security
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
       
        private ApplicationDbContext _context;
        private int _permissionId = 0;
        private IRoleService _roleService;

        public PermissionCheckerAttribute(int permissionId, ApplicationDbContext context, IRoleService roleService)
        {
            _permissionId = permissionId;
            _context = context;
            _roleService = roleService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _roleService =
                (IRoleService) context.HttpContext.RequestServices.GetService(typeof(IRoleService));
            string userId = context.HttpContext.User.Identity.Name;
            if (userId!=null)
            {
                var userName = _context.Users.FirstOrDefault(x => x.Id.ToString() == userId).UserName;
                if (! _roleService.UserCheckPermission(_permissionId, userName))
                {
                   //
                }
            }
            else
            {
                //  
            }
        }
    }
}