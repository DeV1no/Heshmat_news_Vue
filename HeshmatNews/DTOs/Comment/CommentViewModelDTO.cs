using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dadachMovie.DTOs.Comment
{
    public class CommentViewModelDTO:AddCommentDTO
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
