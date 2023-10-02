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
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public int AddItem(NewItemForListVM model)
        {
            var item = _mapper.Map<Item>(model);
            int returnedId = _itemRepository.AddItem(item);
            return returnedId;
        }

        public int AddNewIngredient(IngredientForListVM model)
        {
            var ingredient = _mapper.Map<Ingredient>(model);
            int id = _itemRepository.AddIngredients(ingredient);
            return id;
        }

        public int AddTag(TagForListVM model)
        {
            var tag = _mapper.Map<Tag>(model);
            int id = _itemRepository.AddTag(tag);
            return id;
        }

        public int AddType(TypeForListVM model)
        {
            var type = _mapper.Map<Domain.Model.Type>(model);
            int id = _itemRepository.AddType(type);
            return id;
        }

        public void DeleteIngredient(int id)
        {
            _itemRepository.DeleteIngredients(id);
        }

        public void DeleteItem(int id)
        {
            _itemRepository.DeleteItem(id);
        }

        public void DeleteTag(int id)
        {
            _itemRepository.DeleteTag(id);
        }

        public void DeleteType(int id)
        {
            _itemRepository.DeleteType(id);
        }

        public ListIngredientsForListVM GetAllIngredient(int pageSize, int pageNo, string searchStrin)
        {
            var ingredients = _itemRepository.GetAllIngredients().Where(p => p.Name == searchStrin)
                .ProjectTo<IngredientForListVM>(_mapper.ConfigurationProvider).ToList();
            var ingredientsToShow = ingredients.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var ingredientsList = new ListIngredientsForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                Ingredients = ingredientsToShow,
                SearchString = searchStrin,
                TotalCount = ingredients.Count,
            };
            return ingredientsList;
        }

        public ListItemForListVM GetAllItems(int pageSize, int pageNo, string searchStrin)
        {
            var items = _itemRepository.GetAllItems().Where(p=>p.Name == searchStrin)
                .ProjectTo<ItemForListVM>(_mapper.ConfigurationProvider).ToList();
            var itemsToShow = items.Skip(pageSize * (pageNo -1)).Take(pageSize).ToList();
            var itemsList = new ListItemForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                Items = itemsToShow,
                SearchString = searchStrin,
                TotalCount = items.Count,
            };
            return itemsList;
        }

        public ListTagsForListVM GetAllTags(int pageSize, int pageNo, string searchStrin)
        {
            var tags = _itemRepository.GetAllTags().Where(p => p.Name == searchStrin)
                .ProjectTo<TagForListVM>(_mapper.ConfigurationProvider).ToList();
            var tagsToShow = tags.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var tagsList = new ListTagsForListVM()
            {
                CurrentPage = pageNo,
                Tags = tagsToShow,
                PageSize = pageSize,
                TotalCount = tags.Count,
                SearchString = searchStrin,
            };
            return tagsList;
        }

        public ListTypeForListVM GetAllType(int pageSize, int pageNo, string searchStrin)
        {
            var type = _itemRepository.GetAllTypes().Where(p => p.Name == searchStrin)
                .ProjectTo<TypeForListVM>(_mapper.ConfigurationProvider).ToList();
            var typeToShow = type.Skip(pageSize * (pageNo -1)).Take(pageSize).ToList();
            var typesList = new ListTypeForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                Type = typeToShow,
                TotalCount = type.Count,
                SearchString = searchStrin,
            };
            return typesList;
        }

        public IngredientForListVM GetIngredientDetails(int id)
        {
            var ingredient = _itemRepository.GetIngredientById(id);
            var ingredientToShow = _mapper.Map<IngredientForListVM>(ingredient);
            return ingredientToShow;
        }

        public IngredientForListVM GetIngredientToEditItem(int id)
        {
            var ingredientEdit = _itemRepository.GetIngredientById(id);
            var ingredientToEdit = _mapper.Map<IngredientForListVM>(ingredientEdit);
            return ingredientToEdit;
        }

        public ItemForListVM GetItemDetails(int id)
        {
            var item = _itemRepository.GetItemById(id);
            var itemToShow = _mapper.Map<ItemForListVM>(item);
            return itemToShow;
        }

        public ItemForListVM GetItemToEditItem(int id)
        {
            var item = _itemRepository.GetItemById(id);
            var itemToEdit = _mapper.Map<ItemForListVM>(item);
            return itemToEdit;
        }

        public TagForListVM GetTagDetails(int id)
        {
            var tag = _itemRepository.GetTagById(id);
            var tagToShow = _mapper.Map<TagForListVM>(tag);
            return tagToShow;
        }

        public TagForListVM GetTagToEdit(int id)
        {
            var tag = _itemRepository.GetTagById(id);
            var tagToEdit = _mapper.Map<TagForListVM>(tag);
            return tagToEdit;
        }

        public TypeForListVM GetTypeDetails(int id)
        {
            var type = _itemRepository.GetTypeById(id);
            var typeToShow = _mapper.Map<TypeForListVM>(type);
            return typeToShow;
        }

        public TypeForListVM GetTypeToEdit(int id)
        {
            var type = _itemRepository.GetAllTypes().Where(p=>p.Id==id);
            var typeToEdit = _mapper.Map<TypeForListVM>(type);
            return typeToEdit;
        }

        public void UpdateIngredient(IngredientForListVM model)
        {
            var ingredient = _mapper.Map<Ingredient>(model);
            _itemRepository.EditIngredient(ingredient);
        }

        public void UpdateItem(ItemForListVM model)
        {
            var item = _mapper.Map<Item>(model);
            _itemRepository.EditItem(item);
        }

        public void UpdateTag(TagForListVM model)
        {
            var tag = _mapper.Map<Tag>(model);
            _itemRepository.EditTag(tag);
        }

        public void UpdateType(TypeForListVM model)
        {
            var type = _mapper.Map<WebAppMVC.Domain.Model.Type>(model);
            _itemRepository.EditType(type);
        }

        public int AddItemIngredients(ItemIngredientsForListVM model)
        {
            var itemIngredient = _mapper.Map<ItemIngredient>(model);
            itemIngredient.Id = _itemRepository.AddItemIngredients(itemIngredient);
            return itemIngredient.Id;
        }

        public ListItemIngredientsForListVM GetAllItemIngredientsByIdItem(int pageSize, int pageNo, int id)
        {
            var itemIngredient = _itemRepository.GetAllItemIngredients().Where(p=>p.ItemRef == id)
                .ProjectTo<ItemIngredientsForListVM>(_mapper.ConfigurationProvider).ToList();
            var itemIngredientsToShow = itemIngredient.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var itemIngredientsList = new ListItemIngredientsForListVM()
            {
                Ingredients = itemIngredientsToShow,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = id,

            };
            return itemIngredientsList;
        }

        public ItemIngredientsForListVM EditItemIngredients(int id)
        {
            var itemIngredients = _itemRepository.GetItemIngredientsById(id);
            var itemIngredientToShow = _mapper.Map<ItemIngredientsForListVM>(itemIngredients);
            return itemIngredientToShow;
        }

        public void DeleteItemIngredients(int id)
        {
            _itemRepository.DeleteItemIngredients(id);
        }

        public void UpdateItemIngredient(ItemIngredientsForListVM model)
        {
            var itemIngredient = _mapper.Map<ItemIngredient>(model);
            _itemRepository.EditItemIngredient(itemIngredient);
        }
    }
}