using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.DTOs.Tag
{
    public class TagWithUseCountViewModel
    {
        public int Id { get; set; }

        public string TagName { get; set; }
        public int UseCount { get; set; }
    }
}
