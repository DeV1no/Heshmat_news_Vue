using System.Collections.Generic;
using HeshmastNews.DTOs.Tag;

namespace dadachMovie.Services.Contracts
{
    public interface ITagService
    {
        List<TagViewModelDTO> GetTagList();
        int AddTag(TagDTO model);
        int EditTag(TagUpdateDTO model);
        bool RemoveTag(int tagId);
    }
}