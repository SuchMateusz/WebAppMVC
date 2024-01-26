using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class AlcoDescriptionsRepository : IAlcoDescriptionsRepository
    {
        private readonly Context _context;

        public AlcoDescriptionsRepository(Context context)
        {
            _context = context;
        }

        public int AddAlcoholDescription(AlcoholDescription itemDescription)
        {
            _context.AlcoholDescriptions.Add(itemDescription);
            _context.SaveChanges();
            return itemDescription.Id;
        }

        public void DeleteDescription(int id)
        {
            var desc = _context.AlcoholDescriptions.FirstOrDefault(p => p.Id == id);
            if (desc != null)
            {
                _context.AlcoholDescriptions.Remove(desc);
                _context.SaveChanges();
            }
        }

        public void EditDescription(AlcoholDescription description)
        {
            _context.Attach(description);
            _context.Entry(description).Property("Name").IsModified = true;
            _context.Entry(description).Property("Description").IsModified = true;
            _context.SaveChanges();
            //var desc = _context.AlcoholDescriptions.FirstOrDefault(p => p.Id == description.Id);
            //return desc;
        }

        public IQueryable<AlcoholDescription> GetAllDescriptions()
        {
            var recipes = _context.AlcoholDescriptions;
            return recipes;
        }
    }
}