using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application;
using WebAppMVC.Application.Services;

namespace WebApp.Tests.API
{
    public class ListAlcoholControllerTest
    {
        [Fact]
        public void AddNewAlcohol_ProvidingAddNewAlcoComplete_AddingNewAlco()
        {
            //Arrange
            var AlcoholServ = new AlcoholService();
            //Act

            //Assert


            ////Act
            //var returnedBeerId = service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            ////Assert
            //Assert.Equal(beer.Id, returnedBeerId.Id);

        }
    }
}