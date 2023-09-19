using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppMVC.Domain.Model
{
    public class Tag : EntityModel
    {
        public ICollection<ItemTag> ItemTags { get; set; }
    }
}