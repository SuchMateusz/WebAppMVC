using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;

namespace WebAppMVC.Application.Interfaces
{
    public interface IIngredientsService
    {
        int AddNewIngredient(IngredientForListVM model);

        ListIngredientsForListVM GetAllIngredient(int pageSize, int pageNo, string searchStrin);

        IngredientForListVM GetIngredientToEditItem(int id);

        void UpdateIngredient(IngredientForListVM model);

        void DeleteIngredient(int id);

        IngredientForListVM GetIngredientDetails(int id);

    }
}
