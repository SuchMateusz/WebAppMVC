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

        ItemForListVM GetItemToEditItem(int id);

        void UpdateItem(ItemForListVM model);

        void DeleteItem(int id);

        ItemForListVM GetItemDetails(int id);


        int AddNewIngredient(IngredientForListVM model);

        ListIngredientsForListVM GetAllIngredient(int pageSize, int pageNo, string searchStrin);

        IngredientForListVM GetIngredientToEditItem(int id);

        void UpdateIngredient (IngredientForListVM model);

        void DeleteIngredient(int id);
        
        IngredientForListVM GetIngredientDetails(int id);


        int AddTag(TagForListVM model);

        ListTagsForListVM GetAllTags(int pageSize, int pageNo, string searchStrin);

        TagForListVM GetTagToEdit(int id);

        void UpdateTag(TagForListVM model);

        void DeleteTag(int id);

        TagForListVM GetTagDetails(int id);

        int AddType(NewItemForListVM model);

        ListTypeForListVM GetAllType(int pageSize, int pageNo, string searchStrin);

        TypeForListVM GetTypeToEdit(int id);

        void UpdateType(TypeForListVM model);

        void DeleteType(int id);

        TypeForListVM GetTypeDetails(int id);
    }
}