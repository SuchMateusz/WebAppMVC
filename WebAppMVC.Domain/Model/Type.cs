using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppMVC.Domain.Model
{
    public class Type : EntityModel
    {
        public int ItemId { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}