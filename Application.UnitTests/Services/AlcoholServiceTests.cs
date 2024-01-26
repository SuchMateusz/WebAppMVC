using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Application.Services;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace Application.UnitTests.Services
{
    public class AlcoholServiceTests
    {
        private readonly Mock<IAlcoholRepository> _alcoRepository;
        private readonly Mock<IAlcoCategorysRepository> _alcoCategoryRepository;
        private readonly Mock<IAlcoDescriptionsRepository> _alcoDescriptionsRepository;
        private readonly Mock<IAlcoIngredientRepository> _alcoIngredientRepository;
        private readonly IMapper _mapper;
        private readonly AlcoholService _alcoholService;

        public AlcoholServiceTests()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);
            _alcoRepository = new Mock<IAlcoholRepository>();
            _alcoCategoryRepository = new Mock<IAlcoCategorysRepository>();
            _alcoDescriptionsRepository = new Mock<IAlcoDescriptionsRepository>();
            _alcoIngredientRepository = new Mock<IAlcoIngredientRepository>();
            _alcoholService = new AlcoholService(_alcoRepository.Object, _alcoCategoryRepository.Object, _alcoDescriptionsRepository.Object, _alcoIngredientRepository.Object, _mapper);
        }

        //AlcoholsItemForListVM GetAllAlcohols(int pageSize, int pageNo, string searchStrin);

        //List<Alcohol> GetAlcoholProposal(string ingredient1, string ingredient2, string ingredient3);
        //GetAllAlcohols??

        [Fact]
        public void AddAlcohol_ProperRequest_ProvidingAddNewAlcoholSucced()
        {
            //Arrange
            var item = new Alcohol()
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
            var model = _mapper.Map<NewAlcoholForListVM>(item);
            var alcohol = new Alcohol();
            _alcoRepository.Setup(r => r.AddNewAlcohol(It.IsAny<Alcohol>())).Callback<Alcohol>(bi => alcohol = bi).Returns(1);

            //Act
            int id = _alcoholService.AddAlcohol(model);
            
            //Assert
            _alcoRepository.Verify(r => r.AddNewAlcohol(It.IsAny<Alcohol>()), Times.Once());
            id.Should().Be(1);
        }

        [Fact]
        public void GetAlcoholDetails_ProperRequest__ProvidingToGetAlcoholDetailsByIdIsSucced()
        {
            //Arrange AlcoholForListVM
            var item = new Alcohol()
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
            var model = _mapper.Map<NewAlcoholForListVM>(item);
            var alcohol = new AlcoholForListVM();
            _alcoRepository.Setup(r => r.GetAlcoholById(item.Id)).Returns(item);
            //Act
            var returnedModel = _alcoholService.GetAlcoholDetails(1);

            //Assert
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(item.Name);
        }

        [Fact]
        public void GetAlcoholToEditItem_ProperRequest__ProvidingToGetAlcoholToEditItemIsSucced()
        {
            //Arrange AlcoholForListVM
            var item = new Alcohol()
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
            var model = _mapper.Map<NewAlcoholForListVM>(item);
            var alcohol = new AlcoholForListVM();
            _alcoRepository.Setup(r => r.GetAlcoholById(item.Id)).Returns(item);
            //Act
            var returnedModel = _alcoholService.GetAlcoholToEditItem(1);

            //Assert
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(item.Name);
        }
        
        [Fact]
        public void UpdateAlcoholToEditItem_ProperRequest__ProvidingToUpdateAlcoholWasSucced()
        {
            //Arrange
            var item = new Alcohol()
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
            var model = _mapper.Map<AlcoholForListVM>(item);
            _alcoRepository.Setup(r => r.EditAlcohol(It.IsAny<Alcohol>())).Returns(item);

            //Act
            _alcoholService.UpdateAlcohol(model);

            //Assert
            _alcoRepository.Verify(repo => repo.EditAlcohol(It.IsAny<Alcohol>()), Times.Once());
        }

        //CategoryAlcohol

        //GetCategoryForListVM

        [Fact]
        public void AddCategory_ProperRequest_ProvidingAddNewCategorySucced()
        {
            //Arrange
            var category = new AlcoholCategory()
            {
                Id = 1,
                Name = "Wine",
            };
            var model = _mapper.Map<CategoryForListVM>(category);
            var alcoholCategory = new AlcoholCategory();
            _alcoCategoryRepository.Setup(r => r.AddAlcoholCategory(It.IsAny<AlcoholCategory>())).Callback<AlcoholCategory>(bi => alcoholCategory = bi).Returns(1);

            //Act
            int id = _alcoholService.AddNewCategory(model);

            //Assert
            _alcoCategoryRepository.Verify(r => r.AddAlcoholCategory(It.IsAny<AlcoholCategory>()), Times.Once());
            id.Should().Be(1);
        }

        [Fact]
        public void EditCategory_ProperRequest__ProvidingToGetCategoryAlcoholDetailsToEditIsSucced()
        {
            //Arrange
            var category = new AlcoholCategory()
            {
                Id = 1,
                Name = "Wine",
            };
            var model = _mapper.Map<CategoryForListVM>(category);
            var alcoholCategory = new AlcoholCategory();
            _alcoCategoryRepository.Setup(r => r.GetCategoryById(category.Id)).Returns(category);
            
            //Act
            var returnedModel = _alcoholService.EditCategory(model.Id);

            //Assert
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(category.Name);
        }

        [Fact]
        public void UpdateAlcoholCategory_ProperRequest__ProvidingToUpdateAlcoholCategoryWasSucced()
        {
            //Arrange
            var category = new AlcoholCategory()
            {
                Id = 1,
                Name = "Wine",
            };
            var model = _mapper.Map<CategoryForListVM>(category);

            //Act
            _alcoholService.UpdateCategory(model);

            //Assert
            _alcoCategoryRepository.Verify(repo => repo.EditAlcoholCategory(It.IsAny<AlcoholCategory>()), Times.Once());
        }

        //AlcoholIngredients

        //ListAlcoholsIngredientsForListVM GetAllAlcoholIngredientsByIdItem(int pageSize, int pageNo, int id);


        [Fact]
        public void AddAlcoholIngredient_ProperRequest_ProvidingAddNewAlcoholIngredientSucced()
        {
            //Arrange
            var item = new AlcoholIngredient()
            {
                Id = 1,
                Name = "Wine strawberry",
                AlcoholRef = 1,
                IngredientId = 1,
                NumberOfLiters = 1,
                NumberOfPiece = "1",
                Price = 2,
            };

            var model = _mapper.Map<AlcoholIngredientsForListVM>(item);
            var alcohol = new AlcoholIngredient();
            _alcoIngredientRepository.Setup(r => r.AddAlcoholIngredients(It.IsAny<AlcoholIngredient>())).Callback<AlcoholIngredient>(bi => alcohol = bi).Returns(1);

            //Act
            int id = _alcoholService.AddAlcoholIngredients(model);

            //Assert
            _alcoIngredientRepository.Verify(r => r.AddAlcoholIngredients(It.IsAny<AlcoholIngredient>()), Times.Once());
            id.Should().Be(1);
        }

        [Fact]
        public void EditAlcoholIngredients_ProperRequest__ProvidingToGetAlcoholDetailsToEditWasSucced()
        {
            //Arrange AlcoholForListVM
            var item = new AlcoholIngredient()
            {
                Id = 1,
                Name = "Wine strawberry",
                AlcoholRef = 1,
                IngredientId = 1,
                NumberOfLiters = 1,
                NumberOfPiece = "1",
                Price = 2,
            };

            var model = _mapper.Map<AlcoholIngredientsForListVM>(item);
            var alcohol = new AlcoholIngredient();
            _alcoIngredientRepository.Setup(r => r.GetAlcoholIngredientsById(item.Id)).Returns(item);
            //Act
            var returnedModel = _alcoholService.EditAlcoholIngredients(1);

            //Assert
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(item.Name);
        }

        [Fact]
        public void UpdateAlcoholIngredient_ProperRequest__ProvidingToUpdateAlcoholIngredientWasSucced()
        {
            //Arrange
            var item = new AlcoholIngredient()
            {
                Id = 1,
                Name = "Wine strawberry",
                AlcoholRef = 1,
                IngredientId = 1,
                NumberOfLiters = 1,
                NumberOfPiece = "1",
                Price = 2,
            };

            var model = _mapper.Map<AlcoholIngredientsForListVM>(item);
            var alcohol = new AlcoholIngredient();
            _alcoIngredientRepository.Setup(r => r.GetAlcoholIngredientsById(item.Id)).Returns(item);

            //Act
            _alcoholService.UpdateAlcoholIngredient(model);

            //Assert
            _alcoIngredientRepository.Verify(repo => repo.EditAlcoholIngredient(It.IsAny<AlcoholIngredient>()), Times.Once());
        }

        [Fact]
        public void AddAlcoholDescription_ProperRequest_ProvidingAddDescriptionToAlcoholWasSucced()
        {
            //Arrange
            var item = new AlcoholDescription()
            {
                Id = 1,
                Name = "Wine strawberry",
                AlcoholRef = 1,
                Description = "agasyugeargbae aeyrgbaer aergbae"
            };

            var model = _mapper.Map<DescriptionForListVM>(item);
            var alcohol = new AlcoholDescription();
            _alcoDescriptionsRepository.Setup(r => r.AddAlcoholDescription(It.IsAny<AlcoholDescription>())).Callback<AlcoholDescription>(bi => alcohol = bi).Returns(1);

            //Act
            int id = _alcoholService.AddNewDescription(model);

            //Assert
            _alcoDescriptionsRepository.Verify(r => r.AddAlcoholDescription(It.IsAny<AlcoholDescription>()), Times.Once());
            id.Should().Be(1);
        }

        [Fact]
        public void EditAlcoholDescription_ProperRequest__ProvidingEditAlcoholDescriptionWasSucced()
        {
            //Arrange 
            var item = new AlcoholDescription()
            {
                Id = 1,
                Name = "Wine strawberry",
                AlcoholRef = 1,
                Description = "agasyugeargbae aeyrgbaer aergbae"
            };
            var model = _mapper.Map<DescriptionForListVM>(item);
            //Act
            _alcoholService.EditDescription(model);

            //Assert
            _alcoDescriptionsRepository.Verify(r => r.EditDescription(It.IsAny<AlcoholDescription>()), Times.Once());
        }

    }
}
