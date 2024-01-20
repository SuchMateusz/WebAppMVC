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
            _typesRepo.Setup(r => r.AddType(It.IsAny<WebAppMVC.Domain.Model.Type>())).Callback<WebAppMVC.Domain.Model.Type>(i => tag = i).Returns(1);

            //Act
            int id = _markAlcoService.AddType(model);

            //Assert
            _typesRepo.Verify(r => r.AddType(It.IsAny<WebAppMVC.Domain.Model.Type>()), Times.Once());
            id.Should().Be(1);
        }

        //public void DeleteTag(int id)
        //{
        //    _tagsRepo.DeleteTag(id);
        //    //var tag1 = GetTagDetails(id);
        //    //var tag = _mapper.Map<Tag>(tag1);
        //    //_tagsRepo.DeleteObject(tag);
        //}

        //public void DeleteType(int id)
        //{
        //    _typesRepo.DeleteType(id);
        //}

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

        //public TagForListVM GetTagDetails(int id)
        //{
        //    var tag = _tagsRepo.GetTagById(id);
        //    //var tag = _tagsRepo.GetById(id);
        //    var tagToShow = _mapper.Map<TagForListVM>(tag);
        //    return tagToShow;
        //}

        //public TagForListVM GetTagToEdit(int id)
        //{
        //    var tag = _tagsRepo.GetTagById(id);
        //    //var tag = _tagsRepo.GetById(id);
        //    var tagToEdit = _mapper.Map<TagForListVM>(tag);
        //    return tagToEdit;
        //}

        //public TypeForListVM GetTypeDetails(int id)
        //{
        //    var type = _typesRepo.GetTypeById(id);
        //    var typeToShow = _mapper.Map<TypeForListVM>(type);
        //    return typeToShow;
        //}

        //public TypeForListVM GetTypeToEdit(int id)
        //{
        //    var type = _typesRepo.GetTypeById(id);
        //    var typeToEdit = _mapper.Map<TypeForListVM>(type);
        //    return typeToEdit;
        //}
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
    }
}
