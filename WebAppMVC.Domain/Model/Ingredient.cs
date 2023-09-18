using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Domain.Model
{
    public class Ingredient : EntityModel
    {
        public ICollection<ItemIngredient> ItemIngredients { get; set; }
    }
}
