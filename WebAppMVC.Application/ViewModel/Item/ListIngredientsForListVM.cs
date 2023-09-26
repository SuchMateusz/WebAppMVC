using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class ListIngredientsForListVM
    {
        public List<IngredientForListVM> Ingredients { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public string SearchString { get; set; }

        public int TotalCount { get; set; }
    }
}