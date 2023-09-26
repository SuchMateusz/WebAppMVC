using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            var tag = _mapper.Map<Ingredient>(model);
            int id = _itemRepository.AddIngredients(tag);
            return id;
        }

        public int AddType(NewItemForListVM model)
        {
            var type = _mapper.Map<Ingredient>(model);
            int id = _itemRepository.AddIngredients(type);
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
            throw new NotImplementedException();
        }

        public IngredientForListVM GetIngredientToEditItem(IngredientForListVM model)
        {
            var ingredientEdit = _itemRepository.GetIngredientById(model.Id);
            var ingredientToEdit = _mapper.Map<IngredientForListVM>(ingredientEdit);
            return ingredientToEdit;
        }

        public ItemForListVM GetItemToEditItem(ItemForListVM model)
        {
            var item = _itemRepository.GetItemById(model.Id);
            var itemToEdit = _mapper.Map<ItemForListVM>(model);
            return itemToEdit;
        }

        public TagForListVM GetTagToEdit(TagForListVM model)
        {
            var tag = _itemRepository.GetTagById(model.Id);
            var tagToEdit = _mapper.Map<TagForListVM>(model);
            return tagToEdit;
        }

        public TypeForListVM GetTypeToEdit(TypeForListVM model)
        {
            var type = _itemRepository.GetAllTypes().Where(p=>p.Id==model.Id);
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
    }
}
