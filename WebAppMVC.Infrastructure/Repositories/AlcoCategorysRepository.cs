using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class AlcoCategorysRepository : IAlcoCategorysRepository
    {
        private readonly Context _context;

        public AlcoCategorysRepository(Context context)
        {
            _context = context;
        }

        public int AddAlcoholCategory(AlcoholCategory itemCategory)
        {
            _context.AlcoholCategorys.Add(itemCategory);
            _context.SaveChanges();
            return itemCategory.Id;
        }

        public IQueryable<AlcoholCategory> GetAllCategories()
        {
            var categories = _context.AlcoholCategorys;
            return categories;
        }

        public void DeleteAlcoholCategory(int categoryId)
        {
            var category = _context.AlcoholCategorys.FirstOrDefault(p => p.Id == categoryId);
            if (category != null)
            {
                _context.AlcoholCategorys.Remove(category);
                _context.SaveChanges();
            }
        }

        public void EditAlcoholCategory(AlcoholCategory category)
        {
            _context.Attach(category);
            _context.Entry(category).Property("Name").IsModified = true;
            _context.SaveChanges();
        }

        public AlcoholCategory GetCategoryById(int id)
        {
            var category = _context.AlcoholCategorys.FirstOrDefault(p => p.Id == id);
            return category;
        }

    }
}