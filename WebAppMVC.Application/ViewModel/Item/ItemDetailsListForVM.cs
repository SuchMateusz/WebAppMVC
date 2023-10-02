using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class ItemDetailsListForVM
    {
        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public int YearProduction { get; set; }

        public float SugarContent { get; set; }

        public int Quantity { get; set; }

        public int ItemCategoryId { get; set; }

        public Domain.Model.Type Type { get; set; }

        public List<IngredientForListVM> ItemIngredients { get; set; }

        //public ItemDescription ItemDescription { get; set; }

        public List<ItemTag> ItemTags { get; set; }

        //public List<Categ ItemCategory { get; set; }
    }
}
