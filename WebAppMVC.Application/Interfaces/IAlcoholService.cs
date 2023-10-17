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
        int AddAlcohol(NewAlcoholForListVM model);

        AlcoholsItemForListVM GetAllAlcohols(int pageSize, int pageNo, string searchStrin);

        AlcoholForListVM GetAlcoholToEditItem(int id);

        void UpdateAlcohol(AlcoholForListVM model);

        void DeleteAlcohol(int id);

        AlcoholForListVM GetAlcoholDetails(int id);

        int AddAlcoholIngredients(AlcoholIngredientsForListVM model);

        ListAlcoholsIngredientsForListVM GetAllAlcoholIngredientsByIdItem(int pageSize, int pageNo, int id);

        AlcoholIngredientsForListVM EditAlcoholIngredients(int id);

        void DeleteAlcoholIngredients(int id);

        void UpdateAlcoholIngredient(AlcoholIngredientsForListVM model);

        int AddNewCategory(CategoryForListVM model);

        CategoryForListVM EditCategory(int id);

        void UpdateCategory(CategoryForListVM model);

        void DeleteCategory(int id);

        ListCategoryForVM GetCategoryForListVM(int pageSize, int pageNo, string searchString);
    }
}