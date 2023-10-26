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
        public IQueryable<AlcoholDescription> GetAllDescriptions()
        {
            var recipes = _context.AlcoholDescriptions;
            return recipes;
        }
    }
}