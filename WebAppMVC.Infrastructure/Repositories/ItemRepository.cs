using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Domain.Model;
using Type = WebAppMVC.Domain.Model.Type;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly Context _context;
        public ItemRepository(Context context)
        {
            _context = context;
        }

        public int AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void EditItem(Item item)
        {
            _context.Attach(item);
            _context.Entry(item).Property("Name").IsModified = true;
            _context.Entry(item).Property("TypeId").IsModified = true;
            _context.Entry(item).Property("Price").IsModified = true;
            _context.Entry(item).Property("Quantity").IsModified = true;
            _context.Entry(item).Property("ItemCategoryId").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteItem(int itemId)
        {
            var item = _context.Items.Find(itemId);
            if(item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public Item GetItemById(int itemId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);
            return item;
        }

        public IQueryable<Item> GetAllItems()
        {
            var items = _context.Items;
            return items;
        }

        public IQueryable<ItemDescription> GetAllDescriptions()
        {
            var recipes = _context.ItemDescriptions;
            return recipes;
        }

        public int AddItemCategory(ItemCategory itemCategory)
        {
            _context.ItemCategories.Add(itemCategory);
            _context.SaveChanges();
            return itemCategory.Id;
        }

        public int AddItemDescription(ItemDescription itemDescription)
        {
            _context.ItemDescriptions.Add(itemDescription);
            _context.SaveChanges();
            return itemDescription.Id;
        }

        public IQueryable<ItemCategory> GetAllCategories()
        {
            var categories = _context.ItemCategories;
            return categories;
        }

        public int AddItemIngredients(ItemIngredient ingredients)
        {
            _context.ItemIngredients.Add(ingredients);
            _context.SaveChanges();
            return ingredients.Id;
        }

        public void DeleteItemIngredients(int itemId)
        {
            var item = _context.ItemIngredients.Find(itemId);
            if (item != null)
            {
                _context.ItemIngredients.Remove(item);
                _context.SaveChanges();
            }
        }

        public IQueryable<ItemIngredient> GetAllItemIngredients()
        {
            var ingredients = _context.ItemIngredients;
            return ingredients;
        }

        public ItemIngredient GetItemIngredientsById(int itemId)
        {
            var ingredients = _context.ItemIngredients.Find(itemId);
            return ingredients;
        }

        public int AddIngredients (Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return ingredient.Id;
        }

        public void DeleteIngredients(int ingredientId)
        {
            var ingredient = _context.Ingredients.Find(ingredientId);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            var ingredient = _context.Ingredients.Find(ingredientId);
            return ingredient;
        }

        public IQueryable<Ingredient> GetAllIngredients()
        {
            var ingredients = _context.Ingredients;
            return ingredients;
        }

        public int AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag.Id;
        }

        public void DeleteTag(int id)
        {
            var tagId = _context.Tags.FirstOrDefault(p => p.Id == id);
            if (tagId != null)
            {
                _context.Tags.Remove(tagId);
                _context.SaveChanges();
            }
        }

        public Tag GetTagById(int tagId)
        {
            var tagById = _context.Tags.Find(tagId);
            return tagById;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var allTags = _context.Tags;
            return allTags;
        }

        public int AddType(Type type)
        {
            _context.Types.Add(type);
            _context.SaveChanges();
            return type.Id;
        }

        public void DeleteType(int typeId)
        {
            var type = _context.Types.FirstOrDefault(p => p.Id == typeId);
            if (type != null)
            {
                _context.Types.Remove(type);
                _context.SaveChanges();
            }
        }

        public IQueryable<Type> GetAllTypes()
        {
            var types = _context.Types;
            return types;
        }

        public void EditIngredient(Ingredient ingredient)
        {
            _context.Attach(ingredient);
            _context.Entry(ingredient).Property("Name").IsModified = true;
            _context.Entry(ingredient).Property("Price").IsModified = true;
            _context.SaveChanges();
        }

        public void EditTag(Tag tag)
        {
            _context.Attach(tag);
            _context.Entry(tag).Property("Name").IsModified = true;
            _context.SaveChanges();
        }

        public void EditType(Type type)
        {
            _context.Attach(type);
            _context.Entry(type).Property("Name").IsModified = true;
            _context.Entry(type).Property("ItemId").IsModified = true;
            _context.SaveChanges();
        }
    }
}