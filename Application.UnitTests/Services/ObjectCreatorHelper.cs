using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;
using WebAppMVC.Infrastructure;

namespace Application.UnitTests.Services
{
    public class ObjectCreatorHelper
    {

        public void Seed (Context context)
        {
            //var alcohol = new Faker<Alcohol>()
            //{

            //}
        }
        private static readonly string[] name =
            {
                "Name1", "Name2", "Name3", "Name4"
            };

        public Ingredient GetNewModel()
        {
            var ingredient = new Ingredient()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Price = 1,
            };
            return ingredient;
        }

    }
}
