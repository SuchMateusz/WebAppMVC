using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.ViewModel.Alcohol
{
    public class ListAlcoholsProposalForListVM
    {
        public List<AlcoholIngredient> Alcohols {  get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public string Ingredient1 { get; set; }

        public string Ingredient2 { get; set; }

        public string Ingredient3 { get; set; }

        public int TotalCount { get; set; }
    }
}
