using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Interfaces;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.Services
{
    public class MarkAlcoholService : IMarkAlcoholService
    {
        private readonly IMapper _mapper;
        private readonly ITagsRepository _tagsRepo;
        private readonly ITypesRepository _typesRepo;

        public MarkAlcoholService(ITagsRepository tagsRepository, ITypesRepository typesRepository, IMapper mapper)
        {
            _tagsRepo = tagsRepository;
            _typesRepo = typesRepository;
            _mapper = mapper;
        }

        public int AddTag(TagForListVM model)
        {
            var tag = _mapper.Map<Tag>(model);
            int id = _tagsRepo.AddTag(tag);
            //_tagsRepo.AddNewObject(tag);
            return id;
        }

        public int AddType(TypeForListVM model)
        {
            var type = _mapper.Map<Domain.Model.Type>(model);
            int id = _typesRepo.AddType(type);
            return id;
        }

        public void DeleteTag(int id)
        {
            _tagsRepo.DeleteTag(id);
            //var tag1 = GetTagDetails(id);
            //var tag = _mapper.Map<Tag>(tag1);
            //_tagsRepo.DeleteObject(tag);
        }

        public void DeleteType(int id)
        {
            _typesRepo.DeleteType(id);
        }

        public ListTagsForListVM GetAllTags(int pageSize, int pageNo, string searchString)
        {
            var tags = _tagsRepo.GetAllTags().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<TagForListVM>(_mapper.ConfigurationProvider).ToList();
            //var tags = _tagsRepo.GetAll().Where(p => p.Name.StartsWith(searchString))
            //    .ProjectTo<TagForListVM>(_mapper.ConfigurationProvider).ToList();
            var tagsToShow = tags.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var tagsList = new ListTagsForListVM()
            {
                CurrentPage = pageNo,
                Tags = tagsToShow,
                PageSize = pageSize,
                TotalCount = tags.Count,
                SearchString = searchString,
            };
            return tagsList;
        }

        public ListTypeForListVM GetAllType(int pageSize, int pageNo, string searchString)
        {
            var type = _typesRepo.GetAllTypes().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<TypeForListVM>(_mapper.ConfigurationProvider).ToList();
            var typeToShow = type.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var typesList = new ListTypeForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                AllTypes = typeToShow,
                TotalCount = type.Count,
                SearchString = searchString,
            };
            return typesList;
        }

        public TagForListVM GetTagDetails(int id)
        {
            var tag = _tagsRepo.GetTagById(id);
            //var tag = _tagsRepo.GetById(id);
            var tagToShow = _mapper.Map<TagForListVM>(tag);
            return tagToShow;
        }

        public TagForListVM GetTagToEdit(int id)
        {
            var tag = _tagsRepo.GetTagById(id);
            //var tag = _tagsRepo.GetById(id);
            var tagToEdit = _mapper.Map<TagForListVM>(tag);
            return tagToEdit;
        }

        public TypeForListVM GetTypeDetails(int id)
        {
            var type = _typesRepo.GetTypeById(id);
            var typeToShow = _mapper.Map<TypeForListVM>(type);
            return typeToShow;
        }

        public TypeForListVM GetTypeToEdit(int id)
        {
            var type = _typesRepo.GetTypeById(id);
            var typeToEdit = _mapper.Map<TypeForListVM>(type);
            return typeToEdit;
        }
        public void UpdateTag(TagForListVM model)
        {
            var tag = _mapper.Map<Tag>(model);
            _tagsRepo.EditTag(tag);
            //_tagsRepo.UpdateObject(tag);
        }

        public void UpdateType(TypeForListVM model)
        {
            var type = _mapper.Map<WebAppMVC.Domain.Model.Type>(model);
            _typesRepo.EditType(type);
        }
    }
}