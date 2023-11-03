using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private readonly Context _context;

        public TagsRepository(Context context)
        {
            _context = context;
        }

        public int AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag.Id;
        }

        public void DeleteTag(int id)
        {
            var tagId = _context.Tags.FirstOrDefault(p => p.Id == id);
            if (tagId != null)
            {
                _context.Tags.Remove(tagId);
                _context.SaveChanges();
            }
        }

        public Tag GetTagById(int tagId)
        {
            var tagById = _context.Tags.Find(tagId);
            return tagById;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var allTags = _context.Tags;
            return allTags;
        }

        public void EditTag(Tag tag)
        {
            _context.Tags.Attach(tag);
            _context.Tags.Entry(tag).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}