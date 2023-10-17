using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Domain.Interface
{
    public interface IAlcoCategorysRepository
    {

        public int AddAlcoholCategory(AlcoholCategory itemCategory);

        public IQueryable<AlcoholCategory> GetAllCategories();

        public AlcoholCategory GetCategoryById(int id);

        public void DeleteAlcoholCategory(int categoryId);

        void EditAlcoholCategory(AlcoholCategory category);
    }
}
