using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Model.Common;

namespace WebAppMVC.Domain.Model
{
    public class AlcoholCategory : EntityModel
    {
        public ICollection<Alcohol> Alcohols { get; set; }
    }
}