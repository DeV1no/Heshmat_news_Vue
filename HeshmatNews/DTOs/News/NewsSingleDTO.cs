using dadachMovie.DTOs;
using dadachMovie.DTOs.Comment;
using HeshmastNews.DTOs;
using HeshmastNews.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeshmastNews.DTOs.News
{
    public class NewsSingleDTO
    {
        public string NewsTitle { get; set; }

        public string NewsBody { get; set; }
        public string Poster { get; set; }
        public List<CategoryVewModelDTO> Categories { get; set; }
        public List<TagViewModelDTO> Tags { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserName { get; set; }
        public string CreatedDate { get; set; }
        public string Source { get; set; }
       public List<CommentViewModelDTO> Comments { get; set; }

       //   public List<AddCommentDTO> Comments { get; set; }
    }
}
