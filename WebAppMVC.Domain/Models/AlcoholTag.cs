using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppMVC.Domain.Model
{
    public class AlcoholTag
    {
        public int AlcoholId { get; set; }

        public int TagId { get; set; }

        public Alcohol Alcohol { get; set; }

        public Tag Tag { get; set; }
    }
}