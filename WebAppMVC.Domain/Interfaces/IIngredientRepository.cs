using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Domain.Interface
{
    public interface IIngredientRepository
    {
        public int AddIngredients(Ingredient ingredient);

        public void DeleteIngredients(int ingredientId);

        public Ingredient GetIngredientById(int ingredientId);

        public IQueryable<Ingredient> GetAllIngredients();

        void EditIngredient(Ingredient ingredient);
    }
}
