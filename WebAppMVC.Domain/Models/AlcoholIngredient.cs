using System;
using System.Collections.Generic;
using System.Text;
using WebAppMVC.Domain.Model.Common;

namespace WebAppMVC.Domain.Model
{
    public class AlcoholIngredient : EntityModel
    {
        public int AlcoholRef { get; set; }

        public int IngredientId { get; set; }

        public string NumberOfPiece { get; set; }

        public int NumberOfLiters { get; set; }

        public decimal Price { get; set; }

        public Ingredient Ingredients { get; set; }

        public Alcohol Alcohol { get; set; }
    }
}