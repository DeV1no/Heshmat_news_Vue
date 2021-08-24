using dadachMovie.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.Services.Contracts
{
    public interface IAdminPageService
    {
        public AdminPageItemCountsDTO GetAdminPageItemCounts();
        public List<UserRegisterByDateCountDTO> GetUserRegisterByDateCountDTO();

    }

}
