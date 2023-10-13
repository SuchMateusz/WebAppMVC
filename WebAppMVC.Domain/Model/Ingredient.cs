using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model.Common;

namespace WebAppMVC.Domain.Model
{
    public class Ingredient : EntityModel
    {
        public decimal Price { get; set; }

        public ICollection<AlcoholIngredient> AlcoholIngredients { get; set; }
    }
}
