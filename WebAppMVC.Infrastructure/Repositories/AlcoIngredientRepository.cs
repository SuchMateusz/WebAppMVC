using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class AlcoIngredientRepository : IAlcoIngredientRepository
    {
        private readonly Context _context;

        public AlcoIngredientRepository(Context context)
        {
            _context = context;
        }

        public int AddAlcoholIngredients(AlcoholIngredient ingredients)
        {
            _context.AlcoholIngredients.Add(ingredients);
            _context.SaveChanges();
            return ingredients.Id;
        }

        public void DeleteAlcoholIngredients(int itemId)
        {
            var alcohol = _context.AlcoholIngredients.Find(itemId);
            if (alcohol != null)
            {
                _context.AlcoholIngredients.Remove(alcohol);
                _context.SaveChanges();
            }
        }

        public IQueryable<AlcoholIngredient> GetAllAlcoholIngredients()
        {
            var ingredients = _context.AlcoholIngredients;
            return ingredients;
        }

        public AlcoholIngredient GetAlcoholIngredientsById(int itemId)
        {
            var ingredients = _context.AlcoholIngredients.FirstOrDefault(p => p.Id == itemId);
            return ingredients;
        }

        public void EditAlcoholIngredient(AlcoholIngredient itemingredient)
        {
            _context.Attach(itemingredient);
            _context.Entry(itemingredient).Property("Name").IsModified = true;
            _context.Entry(itemingredient).Property("Price").IsModified = true;
            _context.Entry(itemingredient).Property("NumberOfPiece").IsModified = true;
            _context.Entry(itemingredient).Property("NumberOfLiters").IsModified = true;
            _context.SaveChanges();
        }
    }
}
