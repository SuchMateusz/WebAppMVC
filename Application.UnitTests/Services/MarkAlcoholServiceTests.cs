using AutoMapper;
using Azure;
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
    public class MarkAlcoholServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITagsRepository> _tagsRepo;
        private readonly Mock<ITypesRepository> _typesRepo;
        private readonly MarkAlcoholService _markAlcoService;

        public MarkAlcoholServiceTests()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);
            _tagsRepo = new Mock<ITagsRepository>();
            _typesRepo = new Mock<ITypesRepository>();
            _markAlcoService = new MarkAlcoholService(_tagsRepo.Object, _typesRepo.Object, _mapper);
        }

        [Fact]
        public void AddNewTag_ProperRequest_ProvidingAddNewTagSucced()
        {
            //Arrange
            var tag = new Tag()
            {
                Id = 1,
                Name = "Beer",
            };

            var model = _mapper.Map<TagForListVM>(tag);
            _tagsRepo.Setup(r => r.AddTag(It.IsAny<Tag>())).Callback<Tag>(i => tag = i).Returns(1);

            //Act
            int id = _markAlcoService.AddTag(model);

            //Assert
            _tagsRepo.Verify(r => r.AddTag(It.IsAny<Tag>()), Times.Once());
            id.Should().Be(1);
        }

        [Fact]
        public void AddNewType_ProperRequest_ProvidingAddNewTypeSucced()
        {
            //Arrange
            var type = new WebAppMVC.Domain.Model.Type()
            {
                Id = 1,
                Name = "Beer",
            };

            var model = _mapper.Map<TypeForListVM>(type);
            _typesRepo.Setup(r => r.AddType(It.IsAny<WebAppMVC.Domain.Model.Type>())).Callback<WebAppMVC.Domain.Model.Type>(i => type = i).Returns(1);

            //Act
            int id = _markAlcoService.AddType(model);

            //Assert
            _typesRepo.Verify(r => r.AddType(It.IsAny<WebAppMVC.Domain.Model.Type>()), Times.Once());
            id.Should().Be(1);
        }

        [Fact]
        public void DeleteTag_ProperRequest_ProvidingDeletedTagWasSucced()
        {
            //Arrange
            var tag = new Tag()
            {
                Id = 1,
                Name = "Industrial Robotic",
            };

            //Act
            _markAlcoService.DeleteTag(tag.Id);

            //Assert
            _tagsRepo.Verify(r => r.DeleteTag(tag.Id), Times.Once());
        }

        [Fact]
        public void DeleteType_ProperRequest_ProvidingDeletedTypeWasSucced()
        {
            //Arrange
            var type = new WebAppMVC.Domain.Model.Type()
            {
                Id = 1,
                Name = "Industrial Robotic",
            };

            //Act
            _markAlcoService.DeleteType(type.Id);

            //Assert
            _typesRepo.Verify(r => r.DeleteType(type.Id), Times.Once());
        }

        //public ListTagsForListVM GetAllTags(int pageSize, int pageNo, string searchString)
        //{
        //    var tags = _tagsRepo.GetAllTags().Where(p => p.Name.StartsWith(searchString))
        //        .ProjectTo<TagForListVM>(_mapper.ConfigurationProvider).ToList();
        //    //var tags = _tagsRepo.GetAll().Where(p => p.Name.StartsWith(searchString))
        //    //    .ProjectTo<TagForListVM>(_mapper.ConfigurationProvider).ToList();
        //    var tagsToShow = tags.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
        //    var tagsList = new ListTagsForListVM()
        //    {
        //        CurrentPage = pageNo,
        //        Tags = tagsToShow,
        //        PageSize = pageSize,
        //        TotalCount = tags.Count,
        //        SearchString = searchString,
        //    };
        //    return tagsList;
        //}

        //public ListTypeForListVM GetAllType(int pageSize, int pageNo, string searchString)
        //{
        //    var type = _typesRepo.GetAllTypes().Where(p => p.Name.StartsWith(searchString))
        //        .ProjectTo<TypeForListVM>(_mapper.ConfigurationProvider).ToList();
        //    var typeToShow = type.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
        //    var typesList = new ListTypeForListVM()
        //    {
        //        PageSize = pageSize,
        //        CurrentPage = pageNo,
        //        AllTypes = typeToShow,
        //        TotalCount = type.Count,
        //        SearchString = searchString,
        //    };
        //    return typesList;
        //}

        [Fact]
        public void GetTagDetailsById_ProperRequest_ProvidingToGetTagDetailsByIdWasSucced()
        {
            //Arrange
            var tag = new Tag()
            {
                Id = 1,
                Name = "Beer",
            };

            var model = _mapper.Map<TagForListVM>(tag);
            _tagsRepo.Setup(r => r.GetTagById(tag.Id)).Returns(tag);

            //Act
            var returnedModel = _markAlcoService.GetTagDetails(model.Id);

            //Assert
            //_tagsRepo.Verify(r => r.GetTagById(model.Id), Times.Once());
            returnedModel.Id.Should().Be(tag.Id);
            returnedModel.Name.Should().Be(tag.Name);
        }

        [Fact]
        public void GetTagDetailsByIdToEdit_ProperRequest_ProvidingToGetTagDetailsByIdToEditWasSucced()
        {
            //Arrange
            var tag = new Tag()
            {
                Id = 1,
                Name = "Beer",
            };

            var model = _mapper.Map<TagForListVM>(tag);
            _tagsRepo.Setup(r => r.GetTagById(tag.Id)).Returns(tag);

            //Act
            var returnedModel = _markAlcoService.GetTagToEdit(model.Id);

            //Assert
            _tagsRepo.Verify(r => r.GetTagById(model.Id), Times.Once());
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(tag.Name);
        }

        [Fact]
        public void GetTypeDetailsById_ProperRequest_ProvidingToGetTypeDetailsByIdWasSucced()
        {
            //Arrange
            var type = new WebAppMVC.Domain.Model.Type()
            {
                Id = 1,
                Name = "Beer",
            };

            var model = _mapper.Map<TypeForListVM>(type);
            _typesRepo.Setup(r => r.GetTypeById(type.Id)).Returns(type);

            //Act
            var returnedModel = _markAlcoService.GetTypeDetails(model.Id);

            //Assert
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(type.Name);
        }

        [Fact]
        public void GetTypeDetailsByIdToEdit_ProperRequest_ProvidingToGetTypeDetailsByIdToEditWasSucced()
        {
            //Arrange
            var type = new WebAppMVC.Domain.Model.Type()
            {
                Id = 1,
                Name = "Beer",
            };

            var model = _mapper.Map<TypeForListVM>(type);
            _typesRepo.Setup(r => r.GetTypeById(type.Id)).Returns(type);

            //Act
            var returnedModel = _markAlcoService.GetTypeToEdit(model.Id);

            //Assert
            returnedModel.Id.Should().Be(1);
            returnedModel.Name.Should().Be(type.Name);
        }

        //public void UpdateTag(TagForListVM model)
        //{
        //    var tag = _mapper.Map<Tag>(model);
        //    _tagsRepo.EditTag(tag);
        //    //_tagsRepo.UpdateObject(tag);
        //}

        //public void UpdateType(TypeForListVM model)
        //{
        //    var type = _mapper.Map<WebAppMVC.Domain.Model.Type>(model);
        //    _typesRepo.EditType(type);
        //}

        [Fact]
        public void UpdateTag_ProperRequest__ProvidingToUpdatTagWasSucced()
        {
            //Arrange
            var tag = new Tag()
            {
                Id = 1,
                Name = "Beer",
            };

            var model = _mapper.Map<TagForListVM>(tag);
            _tagsRepo.Setup(r => r.EditTag(tag)).Callback<Tag>(i => tag = i);

            //Act
            _markAlcoService.UpdateTag(model);

            //Assert
            _tagsRepo.Verify(r => r.EditTag(It.IsAny<Tag>()), Times.Once());
        }

        [Fact]
        public void UpdateType_ProperRequest__ProvidingToUpdateTypeWasSucced()
        {
            //Arrange
            var type = new WebAppMVC.Domain.Model.Type()
            {
                Id = 1,
                Name = "Beer",
            };

            var model = _mapper.Map<TypeForListVM>(type);
            _typesRepo.Setup(r => r.EditType(type)).Callback<WebAppMVC.Domain.Model.Type>(i => type = i);

            //Act
            _markAlcoService.UpdateType(model);

            //Assert
            _typesRepo.Verify(r => r.EditType(It.IsAny<WebAppMVC.Domain.Model.Type>()), Times.Once());
        }
    }
}
