using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace WebAppMVC.Application.Interfaces
{
    public interface IAlcoholService
    {
        int AddItem(NewAlcoholForListVM model);

        AlcoholsItemForListVM GetAllItems(int pageSize, int pageNo, string searchStrin);

        AlcoholForListVM GetItemToEditItem(int id);

        void UpdateItem(AlcoholForListVM model);

        void DeleteItem(int id);

        AlcoholForListVM GetItemDetails(int id);

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

        int AddType(TypeForListVM model);

        ListTypeForListVM GetAllType(int pageSize, int pageNo, string searchStrin);

        TypeForListVM GetTypeToEdit(int id);

        void UpdateType(TypeForListVM model);

        void DeleteType(int id);

        TypeForListVM GetTypeDetails(int id);

        int AddItemIngredients (AlcoholIngredientsForListVM model);

        ListAlcoholsIngredientsForListVM GetAllItemIngredientsByIdItem(int pageSize, int pageNo, int id);

        AlcoholIngredientsForListVM EditItemIngredients(int id);

        void DeleteItemIngredients(int id);

        void UpdateItemIngredient(AlcoholIngredientsForListVM model);

        int AddNewCategory(CategoryForListVM model);

        CategoryForListVM EditCategory(int id);

        void UpdateCategory(CategoryForListVM model);

        void DeleteCategory(int id);

        ListCategoryForVM GetCategoryForListVM(int pageSize, int pageNo, string searchString);
    }
}