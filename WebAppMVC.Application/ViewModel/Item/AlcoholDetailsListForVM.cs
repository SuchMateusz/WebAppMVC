using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class AlcoholDetailsListForVM
    {
        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public int YearProduction { get; set; }

        public float SugarContent { get; set; }

        public int Quantity { get; set; }

        public int AlcoholCategoryId { get; set; }

        public Domain.Model.Type Type { get; set; }

        public List<IngredientForListVM> AlcoholIngredients { get; set; }

        public List<AlcoholTag> AlcoholTags { get; set; }
    }
}
