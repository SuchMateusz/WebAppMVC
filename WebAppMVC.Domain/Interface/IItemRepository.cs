using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAppMVC.Domain.Model;
using Type = WebAppMVC.Domain.Model.Type;

namespace WebAppMVC.Application.Interfaces
{
    public interface IItemRepository
    {
        public int AddItem(Item item);

        public void DeleteItem(int itemId);

        public Item GetItemById(int itemId);

        public IQueryable<Item> GetAllItems();

        public int AddItemIngredients(ItemIngredient ingredients);
        
        public void DeleteItemIngredients(int itemId);

        public ItemIngredient GetItemIngredientsById(int itemId);

        public IQueryable<ItemIngredient> GetAllItemIngredients();

        public int AddItemDescription(ItemDescription itemDescription);

        public IQueryable<ItemDescription> GetAllDescriptions();

        public int AddItemCategory(ItemCategory itemCategory);

        public IQueryable<ItemCategory> GetAllCategories();

        public int AddIngredients(Ingredient ingredient);

        public void DeleteIngredients(int ingredientId);

        public Ingredient GetIngredientById(int ingredientId);

        public IQueryable<Ingredient> GetAllIngredients();

        public int AddTag (Tag tag);

        public void DeleteTag(int tagId);

        public Tag GetTagById(int tagId);

        public IQueryable<Tag> GetAllTags();

        public int AddType (Type type);

        public Type GetTypeById(int typeId);

        public void DeleteType(int typeId);

        public IQueryable<Type> GetAllTypes();

        void EditItem(Item item);

        void EditIngredient(Ingredient ingredient);

        void EditTag(Tag tag);

        void EditType(Type type);

        void EditItemIngredient(ItemIngredient itemingredient);
    }
}