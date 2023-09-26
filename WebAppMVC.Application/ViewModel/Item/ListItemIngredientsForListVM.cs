using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class ListItemIngredientsForListVM
    {
        public List<IngredientForListVM> Ingredient { get; set; }

        public List<ItemForListVM> Item { get; set; }

        public int ItemRef { get; set; }

        public int ItemIngredientsId { get; set; }

        public string NumberOfPiece { get; set; }

        public int NumberOfLiters { get; set; }

        public decimal Price { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public string SearchString { get; set; }

        public int TotalCount { get; set; }
    }
}
