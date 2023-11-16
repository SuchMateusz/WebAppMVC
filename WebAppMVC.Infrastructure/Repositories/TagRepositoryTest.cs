//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebAppMVC.Domain.Model;
//using WebAppMVC.Infrastructure.Repositories.Common;

//namespace WebAppMVC.Infrastructure.Repositories
//{
//    public class TagRepositoryTest : BaseRepository<Tag>
//    {
//        public TagRepositoryTest(Context context) : base(context)
//        {
//        }

//        public int AddTag(Tag tag)
//        {
//            AddNewObject(tag);
//            return tag.Id;
//        }

//        public void DeleteTag(int id)
//        {
//            var tag = GetById(id);
//            if (tag != null)
//            {
//                DeleteObject(tag);
//            }
//        }

//        public Tag GetTagById(int tagId)
//        {
//            var tagById = GetById(tagId);
//            return tagById;
//        }

//        public IQueryable<Tag> GetAllTags()
//        {
//            var allTags = GetAll();
//            return allTags;
//        }

//        public void EditTag(Tag tag)
//        {
//            UpdateObject(tag);
//        }
//    }
//}
