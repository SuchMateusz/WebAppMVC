using WebAppMVC.Domain.Model.Common;

namespace WebAppMVC.Domain.Model
{
    public class AlcoholDescription : EntityModel
    {
        public string Description { get; set; }

        public int AlcoholRef { get; set; }

        public virtual Alcohol Alcohol { get; set; }
    }
}