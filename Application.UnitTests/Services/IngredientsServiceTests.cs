using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Application.Services;
using WebAppMVC.Application.ViewModel.Customer;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;
using WebAppMVC.Infrastructure.Repositories;

namespace Application.UnitTests.Services
{
    public class IngredientsServiceTests
    {
        private readonly Mock<IIngredientRepository> _ingredientRepo;
        private readonly IMapper _mapper;
        private readonly IngredientsService _ingredientService;

        public IngredientsServiceTests()
        {
            _ingredientRepo = new Mock<IIngredientRepository>();
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);
            _ingredientService = new IngredientsService(_ingredientRepo.Object, _mapper);
        }

        [Fact]
        public void AddNewIngredients_ProperRequest_ProvidingAddNewIngredientSucced()
        {
            //Arrange
            var ingredient = new Ingredient()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Price = 1,
            };

            var model = _mapper.Map<IngredientForListVM>(ingredient);
            _ingredientRepo.Setup(r => r.AddIngredients(It.IsAny<Ingredient>())).Callback<Ingredient>(i => ingredient = i).Returns(1);

            //Act
            int id = _ingredientService.AddNewIngredient(model);

            //Assert
            _ingredientRepo.Verify(r => r.AddIngredients(It.IsAny<Ingredient>()), Times.Once());
            id.Should().Be(1);
        }

        [Fact]
        public void DeleteIngredients_ProperRequest_ProvidingIngredientWasSuccedDeleted()
        {
            //Arrange

            //Act
            _ingredientService.DeleteIngredient(1);

            //Assert
            _ingredientRepo.Verify(r => r.DeleteIngredients(1), Times.Once());
        }

        //public ListIngredientsForListVM GetAllIngredient(int pageSize, int pageNo, string searchString)
        //{
        //}

        [Fact]
        public void GetIngredientDetailsToEdit_ProperRequest_ProvidingGetIngredientsDetailsForEditWasSucced()
        {
            //Arrange
            var ingredient = new Ingredient()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Price = 1,
            };

            var model = _mapper.Map<IngredientForListVM>(ingredient);
            _ingredientRepo.Setup(r => r.GetIngredientById(ingredient.Id)).Returns(ingredient);

            //Act
            var returnedModel = _ingredientService.GetIngredientDetails(model.Id);

            //Assert
            _ingredientRepo.Verify(r => r.GetIngredientById(ingredient.Id), Times.Once());
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(ingredient.Name);
            returnedModel.Price.Should().Be(ingredient.Price);
        }

        [Fact]
        public void GetIngredientEdit_ProperRequest_ProvidingGetIngredientsEditWasSucced()
        {
            //Arrange
            var ingredient = new Ingredient()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Price = 1,
            };

            var model = _mapper.Map<IngredientForListVM>(ingredient);
            _ingredientRepo.Setup(r => r.GetIngredientById(ingredient.Id)).Returns(ingredient);

            //Act
            var returnedModel = _ingredientService.GetIngredientToEditItem(model.Id);

            //Assert
            _ingredientRepo.Verify(r => r.GetIngredientById(ingredient.Id), Times.Once());
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(ingredient.Name);
            returnedModel.Price.Should().Be(ingredient.Price);
        }

        [Fact]
        public void UpdateIngredient_ProperRequest_ProvidingUpdateIngredientsWasSucced()
        {
            //Arrange
            var ingredient = new Ingredient()
            {
                Id = 1,
                Name = "Industrial Robotic",
                Price = 1,
            };
            var model = _mapper.Map<IngredientForListVM>(ingredient);

            //Act
            _ingredientService.UpdateIngredient(model);

            //Assert
            _ingredientRepo.Verify(r => r.EditIngredient(ingredient), Times.Once());
        }

    }
}
