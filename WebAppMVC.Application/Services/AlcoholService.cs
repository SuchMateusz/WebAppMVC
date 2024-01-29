using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public List<Alcohol> GetAlcoholProposal(string ingredient1, string ingredient2, string ingredient3)
        {
            ingredient1 ??= string.Empty;
            ingredient2 ??= string.Empty;
            ingredient3 ??= string.Empty;
            var model1 = _alcoIngredientRepository.GetAllAlcoholIngredients().Where(p => p.Ingredients.Name.StartsWith(ingredient1)).ToList();
            var model2 = _alcoIngredientRepository.GetAllAlcoholIngredients().Where(p => p.Ingredients.Name.StartsWith(ingredient2)).ToList();
            var model3 = _alcoIngredientRepository.GetAllAlcoholIngredients().Where(p => p.Ingredients.Name.StartsWith(ingredient3)).ToList();

            List<int> ints = new();

            for (int i = 0; i <= model1.Count; i++)
            {
                for (int j = 0; j<= model2.Count; j++)
                {
                    for(int k = 0; k <=model3.Count; k++)
                    {
                        if (model1[i].AlcoholRef == model3[k].AlcoholRef && model2[j].AlcoholRef == model3[k].AlcoholRef && model1[i].AlcoholRef == model2[j].AlcoholRef)
                        {
                            if (ints.Contains(model1[i].AlcoholRef))
                            {

                            }
                            else
                            {
                                ints.Add(model1[i].AlcoholRef);
                            }
                        }
                    }
                }
            }

            List<Alcohol> listAlcoholsToShow = new();
            for(int i = 0; i<=ints.Count; i++)
            {
                var model = _alcoRepository.GetAlcoholById(ints[i]);
                listAlcoholsToShow.Add(model);
            }

            return listAlcoholsToShow;
        }

        public int AddNewDescription (DescriptionForListVM description)
        {
            var item = _mapper.Map<AlcoholDescription>(description);
            int returnedId = _alcoDescriptionsRepository.AddAlcoholDescription(item);
            return returnedId;
        }

        public void DeleteDescription (int id)
        {
            _alcoDescriptionsRepository.DeleteDescription(id);
        }

        public DescriptionForListVM GetAlcoholDescription (int id)
        {
            var model = _alcoDescriptionsRepository.GetAlcoholDescriptionById(id);
            var desc = _mapper.Map<DescriptionForListVM>(model);
            return desc;
        }

        public void EditDescription(DescriptionForListVM model)
        {
            var item = _mapper.Map<AlcoholDescription>(model);
            _alcoDescriptionsRepository.EditDescription(item);
        }
    }
}