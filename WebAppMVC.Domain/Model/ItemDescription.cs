namespace WebAppMVC.Domain.Model
{
    public class ItemDescription : EntityModel
    {
        public string Description { get; set; }

        public int ItemRef { get; set; }

        public virtual Item Item { get; set; }
    }
}