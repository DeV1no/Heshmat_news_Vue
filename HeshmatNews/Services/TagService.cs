using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.DTOs.Tag;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs.Tag;
using HeshmastNews.Entities;

namespace HeshmastNews.Services
{
    public class TagService : ITagService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public TagService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TagViewModelDTO> GetTagList()
        {
            var tagsListDb = _context.Tags.ToList();
            var tags = new List<TagViewModelDTO>();
            foreach (var item in tagsListDb)
            {
                tags.Add(_mapper.Map<TagViewModelDTO>(item));
            }

            return tags;
        }

        public TagViewModelDTO GetTagById(int tagId)
        {
            var tagDb = _context.Tags.FirstOrDefault(x => x.Id == tagId);
            return _mapper.Map<TagViewModelDTO>(tagDb);
        }

        public int AddTag(TagDTO model)
        {
            var tag = _mapper.Map<Tag>(model);
            _context.Add(tag);
            _context.SaveChanges();
            return tag.Id;
        }

        public int EditTag(TagUpdateDTO model)
        {
            bool isExisted = _context.Tags.Any(x => x.Id == model.Id);
            if (!isExisted)
                return -1;
            var tag = _mapper.Map<Tag>(model);
            _context.Update(tag);
            _context.SaveChanges();
            return tag.Id;
        }

        public bool RemoveTag(int tagId)
        {
            var isExisted = _context.Tags.Any(x => x.Id == tagId);
            if (!isExisted)
                return false;
            var tagDb = _context.Tags.FirstOrDefault(x => x.Id == tagId);
            _context.Tags.Remove(tagDb);
            _context.SaveChanges();
            return true;
        }

        public List<TagWithUseCountViewModel> GetTagWithCount()
        {

            var list = new List<TagWithUseCountViewModel>();




            var query = from item in _context.News.SelectMany(x => x.Tags)
                        select item;

            foreach (var item in query)
            {
                list.Add(new TagWithUseCountViewModel
                {

                    Id = item.Id,
                    TagName = item.TagName,
                    UseCount =/* query.GroupBy(x => x.NewsList).Any() ? query.GroupBy(x => x.NewsList).Count() : 0*/

                    query.Where(x => x.Id == item.Id).GroupBy(x => x.NewsList).Count()
                });
            }


            /*(from tag in _context.Tags
                    join news in _context.News on tag.Id equals news.Tags.Select(x => x.Id).ToList().Count

                    select new TagWithUseCountViewModel
                    {
                        Id = tag.Id,
                        TagName = tag.TagName,
                        UseCount = 1
                    });*/


            return list;


        }
    }
}