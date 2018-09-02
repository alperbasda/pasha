using System.Collections.Generic;
using Mermer.Entity.Concrete;

namespace Mermer.Entity.ComplexType
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ProductImageViewModel> Images { get; set; }
    }
}