using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.DTOs
{
    public class CommentCreationDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string content { get; set; }
        public int rate { get; set; }

        [ModelBinder(BinderType = typeof(int))]

        public int NewsId { get; set; }
    }
}