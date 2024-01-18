using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Domain.Interface
{
    public interface IAlcoDescriptionsRepository
    {
        public int AddAlcoholDescription(AlcoholDescription itemDescription);

        public AlcoholDescription EditDescription(AlcoholDescription description);

        public void DeleteDescription(int id);

        public IQueryable<AlcoholDescription> GetAllDescriptions();
    }
}
