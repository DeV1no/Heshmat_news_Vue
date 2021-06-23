using System.Collections.Generic;
using dadachMovie.Services.Contracts;
using HeshmastNews.DTOs.Tag;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.Controllers
{
    [ApiController]
    [Route("api/Tag")]
    public class TagController : ControllerBase
    {
        private ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("TagsList")]
        public List<TagViewModelDTO> GetTagList()
            => _tagService.GetTagList();

        [HttpPost("AddTag")]
        public int AddTag([FromBody] TagDTO model)
            => _tagService.AddTag(model);

        [HttpPut("UpdateTag")]
        public int UpdateTag([FromBody] TagUpdateDTO model)
            => _tagService.EditTag(model);

        [HttpDelete("RemoveTag/{tagId:int}")]
        public bool DeleteTag(int tagId)
            => _tagService.RemoveTag(tagId);
    }
}