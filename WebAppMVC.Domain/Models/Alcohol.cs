using System;
using System.Collections.Generic;
using System.Text;
using WebAppMVC.Domain.Model.Common;

namespace WebAppMVC.Domain.Model
{
    public class Alcohol : EntityModel
    {
        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public int YearProduction { get; set; }

        public float SugarContent { get; set; }

        public int Quantity { get; set; }

        public int AlcoholCategoryId { get; set; }

        public virtual Type Type { get; set; }

        public virtual ICollection<AlcoholIngredient> AlcoholIngredients { get; set; }

        public virtual AlcoholDescription AlcoholDescription { get; set; }

        public virtual ICollection<AlcoholTag> AlcoholTags { get; set; }

        public virtual AlcoholCategory AlcoholCategory { get; set; }
    }
}