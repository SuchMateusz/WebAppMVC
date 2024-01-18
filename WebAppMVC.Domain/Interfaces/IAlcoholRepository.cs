using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAppMVC.Domain.Model;
using WebAppMVC.Domain.Model.Common;

namespace WebAppMVC.Application.Interfaces
{
    public interface IAlcoholRepository
    {
        public int AddNewAlcohol(Alcohol Alcohol);

        public void DeleteAlcohol(int itemId);

        public Alcohol GetAlcoholById(int itemId);

        public IQueryable<Alcohol> GetAllAlcohols();

        public Alcohol EditAlcohol(Alcohol item);
    }
}