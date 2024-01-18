using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;
using WebAppMVC.Domain.Models;
using WebAppMVC.Infrastructure;

namespace Application.UnitTests.Common
{
    public class DbContextFactory
    {
        public static Mock<Context> Create()
        {
            var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var mock = new Mock<Context>(options);
            var context = mock.Object;
            context.Database.EnsureCreated();

            var type = new WebAppMVC.Domain.Model.Type()
            {
                Id =1,
                Name = "TypeTest"
            };
            context.Add(type);

            var tag = new Tag()
            {
                Id = 1,
                Name = "TagTestName"
            };
            context.Add(tag);

            var ingredient = new Ingredient()
            {
                Id = 1,
                Name = "Ingredient1TestName",
                Price = 3,
            };
            context.Add(ingredient);

            var alcoCategory = new AlcoholCategory()
            {
                Id = 1,
                Name = "CategoryAlco",
            };
            context.Add(alcoCategory);

            var alcoDescription = new AlcoholDescription()
            {
                Id = 1,
                Name = "Description name alcohol",
                Description = "It's very soft wine and half sweet great to meal",
                AlcoholRef = 1,
            };
            context.Add(alcoDescription);

            var alcoIngredients = new AlcoholIngredient()
            {
                Id = 1,
                IngredientId = 1,
                AlcoholRef = 1,
                NumberOfLiters = 1,
                NumberOfPiece = "1kg",
                Price = 3,
            };
            context.Add(alcoIngredients);

            var alcohol = new Alcohol()
            {
                Id = 1,
                Name = "Wine strawberry",
                TypeId = 1,
                Price = 25,
                YearProduction = 2023,
                SugarContent = 5,
                Quantity = 10,
                AlcoholCategoryId = 1,
            };
            context.Add(alcohol);

            var alcoTag = new AlcoholTag()
            {
                AlcoholId = 1,
                TagId = 1,
            };
            context.Add(alcoTag);

            context.SaveChanges();

            return mock;
        }

        public static void Destroy(Context context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
