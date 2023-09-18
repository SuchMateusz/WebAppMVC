using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppMVC.Domain.Model
{
    public class Item : EntityModel
    {
        public int TypeId { get; set; }

        public int Price { get; set; }

        public int YearProduction { get; set; }

        public int SugarContent { get; set; }

        public int Quantity { get; set; }

        public int ItemCategoryId { get; set; }

        public virtual Type Type { get; set; }

        public virtual ICollection<ItemIngredient> ItemIngredients { get; set; }

        public ItemDescription ItemDescription { get; set; }

        public virtual ICollection<ItemTag> ItemTags { get; set; }

        public ItemCategory ItemCategory { get; set; }
    }
}
