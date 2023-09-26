using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace WebAppMVC.Application.Interfaces
{
    public interface IItemService
    {
        int AddItem(NewItemForListVM model);

        ListItemForListVM GetAllItems(int pageSize, int pageNo, string searchStrin);

        ItemForListVM GetItemToEditItem(ItemForListVM model);

        void UpdateItem(ItemForListVM model);

        void DeleteItem(int id);


        int AddNewIngredient(IngredientForListVM model);

        ListIngredientsForListVM GetAllIngredient(int pageSize, int pageNo, string searchStrin);

        IngredientForListVM GetIngredientToEditItem(IngredientForListVM model);

        void UpdateIngredient (IngredientForListVM model);

        void DeleteIngredient(int id);


        int AddTag(TagForListVM model);

        ListTagsForListVM GetAllTags(int pageSize, int pageNo, string searchStrin);

        TagForListVM GetTagToEdit(TagForListVM model);

        void UpdateTag(TagForListVM model);

        void DeleteTag(int id);


        int AddType(NewItemForListVM model);

        ListTypeForListVM GetAllType(int pageSize, int pageNo, string searchStrin);

        TypeForListVM GetTypeToEdit(TypeForListVM model);

        void UpdateType(TypeForListVM model);

        void DeleteType(int id);

    }
}
