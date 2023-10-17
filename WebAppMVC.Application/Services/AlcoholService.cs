using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Customer;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.Services
{
    public class AlcoholService : IAlcoholService
    {
        private readonly IAlcoholRepository _alcoRepository;
        private readonly IAlcoCategorysRepository _alcoCategoryRepository;
        private readonly IAlcoDescriptionsRepository _alcoDescriptionsRepository;
        private readonly IAlcoIngredientRepository _alcoIngredientRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly ITypesRepository _typesRepository;

        private readonly IMapper _mapper;

        public AlcoholService(IAlcoholRepository alcoRepository, IAlcoCategorysRepository alcoCategorysRepository, IAlcoDescriptionsRepository alcoDescriptionsRepository, IAlcoIngredientRepository alcoIngredientRepository, IIngredientRepository ingredientRepository, ITagsRepository tagsRepository, ITypesRepository typesRepository, IMapper mapper)

        {
            _alcoRepository = alcoRepository;
            _alcoCategoryRepository = alcoCategorysRepository;
            _alcoDescriptionsRepository = alcoDescriptionsRepository;
            _alcoIngredientRepository = alcoIngredientRepository;
            _ingredientRepository = ingredientRepository;
            _tagsRepository = tagsRepository;
            _typesRepository = typesRepository;
            _mapper = mapper;
        }

        public int AddAlcohol(NewAlcoholForListVM model)
        {
            var item = _mapper.Map<Alcohol>(model);
            int returnedId = _alcoRepository.AddNewAlcohol(item);
            return returnedId;
        }

        public int AddNewIngredient(IngredientForListVM model)
        {
            var ingredient = _mapper.Map<Ingredient>(model);
            int id = _ingredientRepository.AddIngredients(ingredient);
            return id;
        }

        public int AddTag(TagForListVM model)
        {
            var tag = _mapper.Map<Tag>(model);
            int id = _tagsRepository.AddTag(tag);
            return id;
        }

        public int AddType(TypeForListVM model)
        {
            var type = _mapper.Map<Domain.Model.Type>(model);
            int id = _typesRepository.AddType(type);
            return id;
        }

        public int AddNewCategory(CategoryForListVM model)
        {
            var category = _mapper.Map<Domain.Model.AlcoholCategory>(model);
            int id = _alcoCategoryRepository.AddAlcoholCategory(category);
            return id;
        }

        public void DeleteIngredient(int id)
        {
            _ingredientRepository.DeleteIngredients(id);
        }

        public void DeleteAlcohol(int id)
        {
            _alcoRepository.DeleteAlcohol(id);
        }

        public void DeleteTag(int id)
        {
            _tagsRepository.DeleteTag(id);
        }

        public void DeleteType(int id)
        {
            _typesRepository.DeleteType(id);
        }

        public ListIngredientsForListVM GetAllIngredient(int pageSize, int pageNo, string searchString)
        {
            var ingredients = _ingredientRepository.GetAllIngredients().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<IngredientForListVM>(_mapper.ConfigurationProvider).ToList();
            var ingredientsToShow = ingredients.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var ingredientsList = new ListIngredientsForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                Ingredients = ingredientsToShow,
                SearchString = searchString,
                TotalCount = ingredients.Count,
            };
            return ingredientsList;
        }

        public AlcoholsItemForListVM GetAllAlcohols(int pageSize, int pageNo, string searchString)
        {
            var items = _alcoRepository.GetAllAlcohols().Where(p=>p.Name.StartsWith(searchString))
                .ProjectTo<AlcoholForListVM>(_mapper.ConfigurationProvider).ToList();
            var itemsToShow = items.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var itemsList = new AlcoholsItemForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                Alcohols = itemsToShow,
                SearchString = searchString,
                TotalCount = items.Count,
            };
            return itemsList;
        }

        public ListTagsForListVM GetAllTags(int pageSize, int pageNo, string searchString)
        {
            var tags = _tagsRepository.GetAllTags().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<TagForListVM>(_mapper.ConfigurationProvider).ToList();
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
            var type = _typesRepository.GetAllTypes().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<TypeForListVM>(_mapper.ConfigurationProvider).ToList();
            var typeToShow = type.Skip(pageSize * (pageNo -1)).Take(pageSize).ToList();
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

        public IngredientForListVM GetIngredientDetails(int id)
        {
            var ingredient = _ingredientRepository.GetIngredientById(id);
            var ingredientToShow = _mapper.Map<IngredientForListVM>(ingredient);
            return ingredientToShow;
        }

        public IngredientForListVM GetIngredientToEditItem(int id)
        {
            var ingredientEdit = _ingredientRepository.GetIngredientById(id);
            var ingredientToEdit = _mapper.Map<IngredientForListVM>(ingredientEdit);
            return ingredientToEdit;
        }

        public AlcoholForListVM GetAlcoholDetails(int id)
        {
            var item = _alcoRepository.GetAlcoholById(id);
            var itemToShow = _mapper.Map<AlcoholForListVM>(item);
            return itemToShow;
        }

        public AlcoholForListVM GetAlcoholToEditItem(int id)
        {
            var item = _alcoRepository.GetAlcoholById(id);
            var itemToEdit = _mapper.Map<AlcoholForListVM>(item);
            return itemToEdit;
        }

        public TagForListVM GetTagDetails(int id)
        {
            var tag = _tagsRepository.GetTagById(id);
            var tagToShow = _mapper.Map<TagForListVM>(tag);
            return tagToShow;
        }

        public TagForListVM GetTagToEdit(int id)
        {
            var tag = _tagsRepository.GetTagById(id);
            var tagToEdit = _mapper.Map<TagForListVM>(tag);
            return tagToEdit;
        }

        public TypeForListVM GetTypeDetails(int id)
        {
            var type = _typesRepository.GetTypeById(id);
            var typeToShow = _mapper.Map<TypeForListVM>(type);
            return typeToShow;
        }

        public TypeForListVM GetTypeToEdit(int id)
        {
            var type = _typesRepository.GetTypeById(id);
            var typeToEdit = _mapper.Map<TypeForListVM>(type);
            return typeToEdit;
        }

        public CategoryForListVM EditCategory(int id)
        {
            var category = _alcoCategoryRepository.GetCategoryById(id);
            var categoryToShow = _mapper.Map<CategoryForListVM>(category);
            return categoryToShow;
        }

        public void UpdateIngredient(IngredientForListVM model)
        {
            var ingredient = _mapper.Map<Ingredient>(model);
            _ingredientRepository.EditIngredient(ingredient);
        }

        public void UpdateAlcohol(AlcoholForListVM model)
        {
            var item = _mapper.Map<Alcohol>(model);
            _alcoRepository.EditAlcohol(item);
        }

        public void UpdateTag(TagForListVM model)
        {
            var tag = _mapper.Map<Tag>(model);
            _tagsRepository.EditTag(tag);
        }

        public void UpdateType(TypeForListVM model)
        {
            var type = _mapper.Map<WebAppMVC.Domain.Model.Type>(model);
            _typesRepository.EditType(type);
        }

        public int AddAlcoholIngredients(AlcoholIngredientsForListVM model)
        {
            var itemIngredient = _mapper.Map<AlcoholIngredient>(model);
            itemIngredient.Id = _alcoIngredientRepository.AddAlcoholIngredients(itemIngredient);
            return itemIngredient.Id;
        }

        public ListAlcoholsIngredientsForListVM GetAllAlcoholIngredientsByIdItem(int pageSize, int pageNo, int id)
        {
                var item = _alcoIngredientRepository.GetAllAlcoholIngredients()
                .ProjectTo<AlcoholIngredientsForListVM>(_mapper.ConfigurationProvider).ToList();
                var itemIngredientsToShow = item.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
                var itemIngredientsList = new ListAlcoholsIngredientsForListVM()
                {
                    Ingredients = itemIngredientsToShow,
                    PageSize = pageSize,
                    CurrentPage = pageNo,
                    SearchString = id,

                };
                return itemIngredientsList;
        }

        public AlcoholIngredientsForListVM EditAlcoholIngredients(int id)
        {
            var itemIngredients = _alcoIngredientRepository.GetAlcoholIngredientsById(id);
            var itemIngredientToShow = _mapper.Map<AlcoholIngredientsForListVM>(itemIngredients);
            return itemIngredientToShow;
        }

        public void DeleteAlcoholIngredients(int id)
        {
            _alcoIngredientRepository.DeleteAlcoholIngredients(id);
        }

        public void UpdateAlcoholIngredient(AlcoholIngredientsForListVM model)
        {
            var itemIngredient = _mapper.Map<AlcoholIngredient>(model);
            _alcoIngredientRepository.EditAlcoholIngredient(itemIngredient);
        }


        public void UpdateCategory(CategoryForListVM model)
        {
            var category = _mapper.Map<AlcoholCategory>(model);
            _alcoCategoryRepository.EditAlcoholCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _alcoCategoryRepository.DeleteAlcoholCategory(id);
        }

        public ListCategoryForVM GetCategoryForListVM(int pageSize, int pageNo, string searchString)
        {
            var category = _alcoCategoryRepository.GetAllCategories().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<CategoryForListVM>(_mapper.ConfigurationProvider).ToList();
            var categoryToShow = category.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var categoryToList = new ListCategoryForVM()
            {
                PageSize = pageSize,
                Category = category,
                CurrentPage = pageNo,
                SearchString = searchString,
                TotalCount = category.Count,
            };
            return categoryToList;
        }
    }
}