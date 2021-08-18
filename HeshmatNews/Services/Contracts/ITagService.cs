using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs.Tag;
using HeshmastNews.DTOs.Tag;

namespace dadachMovie.Services.Contracts
{
    public interface ITagService
    {
        List<TagViewModelDTO> GetTagList();
        List<TagWithUseCountViewModel> GetTagWithCount();
        TagViewModelDTO GetTagById(int tagId);
        int AddTag(TagDTO model);
        int EditTag(TagUpdateDTO model);
        bool RemoveTag(int tagId);
    }
}