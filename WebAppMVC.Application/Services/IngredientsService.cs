using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientsService(IIngredientRepository ingredientRepository, IMapper mapper) 
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }


        public int AddNewIngredient(IngredientForListVM model)
        {
            var ingredient = _mapper.Map<Ingredient>(model);
            int id = _ingredientRepository.AddIngredients(ingredient);
            return id;
        }

        public void DeleteIngredient(int id)
        {
            _ingredientRepository.DeleteIngredients(id);
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

        public void UpdateIngredient(IngredientForListVM model)
        {
            var ingredient = _mapper.Map<Ingredient>(model);
            _ingredientRepository.EditIngredient(ingredient);
        }
    }
}
