using dadachMovie.DTOs.Admin;
using dadachMovie.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        private IAdminPageService _adminPageService;

        public AdminController(IAdminPageService adminPageService)
        {
            _adminPageService = adminPageService;
        }

        [HttpGet("ItemCounts")]
        public AdminPageItemCountsDTO GetAdminItemCount()
            => _adminPageService.GetAdminPageItemCounts();

    }
}
