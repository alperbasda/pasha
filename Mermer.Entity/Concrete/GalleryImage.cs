using Mermer.Core;

namespace Mermer.Entity.Concrete
{
    public class GalleryImage : IEntity
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }
    }
}