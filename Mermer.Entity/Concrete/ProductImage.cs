using Mermer.Core;

namespace Mermer.Entity.Concrete
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string ImageDescription { get; set; }

        public string ImagePath { get; set; }

        public bool IsFirst { get; set; }
    }
}