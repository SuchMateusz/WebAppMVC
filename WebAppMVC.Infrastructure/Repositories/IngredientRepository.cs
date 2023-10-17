using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly Context _context;

        public IngredientRepository(Context context)
        {
            _context = context;
        }

        public int AddIngredients(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return ingredient.Id;
        }

        public void DeleteIngredients(int ingredientId)
        {
            var ingredient = _context.Ingredients.Find(ingredientId);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            var ingredient = _context.Ingredients.Find(ingredientId);
            return ingredient;
        }

        public IQueryable<Ingredient> GetAllIngredients()
        {
            var ingredients = _context.Ingredients;
            return ingredients;
        }
        public void EditIngredient(Ingredient ingredient)
        {
            _context.Attach(ingredient);
            _context.Entry(ingredient).Property("Name").IsModified = true;
            _context.Entry(ingredient).Property("Price").IsModified = true;
            _context.SaveChanges();
        }
    }
}