using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Domain.Interface
{
    public interface ITagsRepository
    {
        public int AddTag(Tag tag);

        public void DeleteTag(int tagId);

        public Tag GetTagById(int tagId);

        public IQueryable<Tag> GetAllTags();

        void EditTag(Tag tag);
    }
}
