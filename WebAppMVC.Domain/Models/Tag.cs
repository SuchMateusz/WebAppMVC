using System;
using System.Collections.Generic;
using System.Text;
using WebAppMVC.Domain.Model.Common;

namespace WebAppMVC.Domain.Model
{
    public class Tag : EntityModel
    {
        public ICollection<AlcoholTag> AlcoholTags { get; set; }
    }
}