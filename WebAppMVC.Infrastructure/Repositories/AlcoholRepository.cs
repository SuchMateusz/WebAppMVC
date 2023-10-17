using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Domain.Model;
using Type = WebAppMVC.Domain.Model.Type;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class AlcoholRepository : IAlcoholRepository
    {
        private readonly Context _context;

        public AlcoholRepository(Context context)
        {
            _context = context;
        }

        public int AddNewAlcohol(Alcohol alcohol)
        {
            _context.Alcohols.Add(alcohol);
            _context.SaveChanges();
            return alcohol.Id;
        }

        public void EditAlcohol(Alcohol alcohol)
        {
            _context.Attach(alcohol);
            _context.Entry(alcohol).Property("Name").IsModified = true;
            _context.Entry(alcohol).Property("TypeId").IsModified = true;
            _context.Entry(alcohol).Property("Price").IsModified = true;
            _context.Entry(alcohol).Property("Quantity").IsModified = true;
            _context.Entry(alcohol).Property("ItemCategoryId").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteAlcohol(int itemId)
        {
            var alcohol = _context.Alcohols.Find(itemId);
            if(alcohol != null)
            {
                _context.Alcohols.Remove(alcohol);
                _context.SaveChanges();
            }
        }

        public Alcohol GetAlcoholById(int itemId)
        {
            var alcohol = _context.Alcohols.FirstOrDefault(i => i.Id == itemId);
            return alcohol;
        }

        public IQueryable<Alcohol> GetAllAlcohols()
        {
            var alcohols = _context.Alcohols;
            return alcohols;
        }
    }
}