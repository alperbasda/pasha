using System.Collections.Generic;
using Mermer.Entity.Concrete;

namespace Mermer.Entity.ComplexType
{
    public class UserOrderGetModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int ProductId { get; set; }
        
        public List<ProductImageViewModel> ProductImages { get; set; }
        
        public string Description { get; set; }

    }
}