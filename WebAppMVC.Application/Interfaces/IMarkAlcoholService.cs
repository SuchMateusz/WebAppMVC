using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace WebAppMVC.Application.Interfaces
{
    public interface IMarkAlcoholService
    {
        int AddTag(TagForListVM model);

        ListTagsForListVM GetAllTags(int pageSize, int pageNo, string searchStrin);

        TagForListVM GetTagToEdit(int id);

        void UpdateTag(TagForListVM model);

        void DeleteTag(int id);

        TagForListVM GetTagDetails(int id);

         int AddType(TypeForListVM model);

        ListTypeForListVM GetAllType(int pageSize, int pageNo, string searchStrin);

        TypeForListVM GetTypeToEdit(int id);

        void UpdateType(TypeForListVM model);

        void DeleteType(int id);

        TypeForListVM GetTypeDetails(int id);
    }
}
