using System.Collections.Generic;
using Mermer.Entity.Concrete;

namespace Mermer.Entity.ComplexType
{
    public class OnepageModel
    {
        public List<Category> Categories { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public List<GalleryImage> Images { get; set; }

        public Site Site { get; set; }
    }
}