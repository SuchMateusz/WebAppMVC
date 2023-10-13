using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAppMVC.Domain.Model;
using Type = WebAppMVC.Domain.Model.Type;

namespace WebAppMVC.Application.Interfaces
{
    public interface IAlcoholRepository
    {
        public int AddItem(Alcohol Alcohol);

        public void DeleteItem(int itemId);

        public Alcohol GetItemById(int itemId);

        public IQueryable<Alcohol> GetAllItems();

        public int AddItemIngredients(AlcoholIngredient ingredients);
        
        public void DeleteItemIngredients(int itemId);

        public AlcoholIngredient GetItemIngredientsById(int itemId);

        public IQueryable<AlcoholIngredient> GetAllItemIngredients();

        public int AddItemDescription(AlcoholDescription itemDescription);

        public IQueryable<AlcoholDescription> GetAllDescriptions();

        public int AddItemCategory(AlcoholCategory itemCategory);

        public IQueryable<AlcoholCategory> GetAllCategories();

        public AlcoholCategory GetCategoryById(int id);

        public void DeleteItemCategory(int categoryId);

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

        void EditItem(Alcohol item);

        void EditIngredient(Ingredient ingredient);

        void EditTag(Tag tag);

        void EditType(Type type);

        void EditItemIngredient(AlcoholIngredient itemingredient);

        void EditItemCategory(AlcoholCategory category);
    }
}