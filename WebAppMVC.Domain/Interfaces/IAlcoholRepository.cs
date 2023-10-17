﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.Interfaces
{
    public interface IAlcoholRepository
    {
        public int AddNewAlcohol(Alcohol Alcohol);

        public void DeleteAlcohol(int itemId);

        public Alcohol GetAlcoholById(int itemId);

        public IQueryable<Alcohol> GetAllAlcohols();

        void EditAlcohol(Alcohol item);
    }
}