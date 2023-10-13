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
    public class AlcoholRepository : IAlcoholRepository
    {
        private readonly Context _context;
        public AlcoholRepository(Context context)
        {
            _context = context;
        }

        public int AddItem(Alcohol item)
        {
            _context.Alcohols.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void EditItem(Alcohol item)
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
            var item = _context.Alcohols.Find(itemId);
            if(item != null)
            {
                _context.Alcohols.Remove(item);
                _context.SaveChanges();
            }
        }

        public Alcohol GetItemById(int itemId)
        {
            var item = _context.Alcohols.FirstOrDefault(i => i.Id == itemId);
            return item;
        }

        public IQueryable<Alcohol> GetAllItems()
        {
            var alcohols = _context.Alcohols;
            return alcohols;
        }

        public IQueryable<AlcoholDescription> GetAllDescriptions()
        {
            var recipes = _context.AlcoholDescriptions;
            return recipes;
        }

        public int AddItemCategory(AlcoholCategory itemCategory)
        {
            _context.AlcoholCategorys.Add(itemCategory);
            _context.SaveChanges();
            return itemCategory.Id;
        }

        public int AddItemDescription(AlcoholDescription itemDescription)
        {
            _context.AlcoholDescriptions.Add(itemDescription);
            _context.SaveChanges();
            return itemDescription.Id;
        }

        public IQueryable<AlcoholCategory> GetAllCategories()
        {
            var categories = _context.AlcoholCategorys;
            return categories;
        }

        public int AddItemIngredients(AlcoholIngredient ingredients)
        {
            _context.AlcoholIngredients.Add(ingredients);
            _context.SaveChanges();
            return ingredients.Id;
        }

        public void DeleteItemIngredients(int itemId)
        {
            var item = _context.AlcoholIngredients.Find(itemId);
            if (item != null)
            {
                _context.AlcoholIngredients.Remove(item);
                _context.SaveChanges();
            }
        }

        public IQueryable<AlcoholIngredient> GetAllItemIngredients()
        {
            var ingredients = _context.AlcoholIngredients;
            return ingredients;
        }

        public AlcoholIngredient GetItemIngredientsById(int itemId)
        {
            var ingredients = _context.AlcoholIngredients.FirstOrDefault(p=>p.Id == itemId);
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

        public void EditItemIngredient(AlcoholIngredient itemingredient)
        {
            _context.Attach(itemingredient);
            _context.Entry(itemingredient).Property("Name").IsModified = true;
            _context.Entry(itemingredient).Property("Price").IsModified = true;
            _context.Entry(itemingredient).Property("NumberOfPiece").IsModified=true;
            _context.Entry(itemingredient).Property("NumberOfLiters").IsModified = true;
            _context.SaveChanges();
        }

        public Type GetTypeById(int typeId)
        {
            var type =_context.Types.FirstOrDefault(p => p.Id == typeId);
            return type;
        }

        public void DeleteItemCategory(int categoryId)
        {
            var category = _context.AlcoholCategorys.FirstOrDefault(p => p.Id == categoryId);
            if (category != null)
            {
                _context.AlcoholCategorys.Remove(category);
                _context.SaveChanges();
            }
        }

        public void EditItemCategory(AlcoholCategory category)
        {
            _context.Attach(category);
            _context.Entry(category).Property("Name").IsModified = true;
        }

        public AlcoholCategory GetCategoryById(int id)
        {
            var category = _context.AlcoholCategorys.FirstOrDefault(p => p.Id == id);
            return category;
        }
    }
}