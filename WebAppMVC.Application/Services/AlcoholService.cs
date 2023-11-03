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
using WebAppMVC.Domain.Interfaces;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.Services
{
    public class AlcoholService : IAlcoholService
    {
        private readonly IAlcoholRepository _alcoRepository;
        private readonly IAlcoCategorysRepository _alcoCategoryRepository;
        private readonly IAlcoDescriptionsRepository _alcoDescriptionsRepository;
        private readonly IAlcoIngredientRepository _alcoIngredientRepository;
        private readonly IMapper _mapper;

        public AlcoholService(IAlcoholRepository alcoRepository, IAlcoCategorysRepository alcoCategorysRepository, IAlcoDescriptionsRepository alcoDescriptionsRepository, IAlcoIngredientRepository alcoIngredientRepository, IMapper mapper)
        {
            _alcoRepository = alcoRepository;
            _alcoCategoryRepository = alcoCategorysRepository;
            _alcoDescriptionsRepository = alcoDescriptionsRepository;
            _alcoIngredientRepository = alcoIngredientRepository;
            _mapper = mapper;
        }

        public int AddAlcohol(NewAlcoholForListVM model)
        {
            var item = _mapper.Map<Alcohol>(model);
            int returnedId = _alcoRepository.AddNewAlcohol(item);
            return returnedId;
        }

        public int AddNewCategory(CategoryForListVM model)
        {
            var category = _mapper.Map<Domain.Model.AlcoholCategory>(model);
            int id = _alcoCategoryRepository.AddAlcoholCategory(category);
            return id;
        }

        public void DeleteAlcohol(int id)
        {
            _alcoRepository.DeleteAlcohol(id);
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

        public CategoryForListVM EditCategory(int id)
        {
            var category = _alcoCategoryRepository.GetCategoryById(id);
            var categoryToShow = _mapper.Map<CategoryForListVM>(category);
            return categoryToShow;
        }

        public void UpdateAlcohol(AlcoholForListVM model)
        {
            var item = _mapper.Map<Alcohol>(model);
            _alcoRepository.EditAlcohol(item);
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