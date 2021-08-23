using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.DTOs.Admin
{
    public class AdminPageItemCountsDTO
    {
        public int NewsCount { get; set; }
        public int CategoryCount { get; set; }
        public int RolesCount { get; set; }
        public int UserCount { get; set; }
    }
}
