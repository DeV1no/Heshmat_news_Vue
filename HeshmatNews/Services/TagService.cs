using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using AutoMapper;
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
    }
}