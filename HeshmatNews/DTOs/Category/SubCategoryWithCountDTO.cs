using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.DTOs.Category
{
    public class SubCategoryWithCountDTO
    {
        public int CategoryId { get; set; }
        public string CateGoryName { get; set; }
        public int UseCount { get; set; }
    }
}
