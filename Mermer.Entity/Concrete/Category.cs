using Mermer.Core;

namespace Mermer.Entity.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

    }
}