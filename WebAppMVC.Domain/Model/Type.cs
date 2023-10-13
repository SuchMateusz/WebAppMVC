using System;
using System.Collections.Generic;
using System.Text;
using WebAppMVC.Domain.Model.Common;

namespace WebAppMVC.Domain.Model
{
    public class Type : EntityModel
    {
        public virtual ICollection<Alcohol> Alcohols { get; set; }
    }
}