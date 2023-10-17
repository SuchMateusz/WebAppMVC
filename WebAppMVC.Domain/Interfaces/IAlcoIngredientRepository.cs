using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Domain.Interface
{
    public interface IAlcoIngredientRepository
    {
        public int AddAlcoholIngredients(AlcoholIngredient ingredients);

        public void DeleteAlcoholIngredients(int itemId);

        public AlcoholIngredient GetAlcoholIngredientsById(int itemId);

        public IQueryable<AlcoholIngredient> GetAllAlcoholIngredients();

        void EditAlcoholIngredient(AlcoholIngredient itemingredient);
    }
}