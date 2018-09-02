using System.Collections.Generic;
using Mermer.Core.DataAccess;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepositoryBase<Product>
    {
        string GetProductsInCategory(int id);
        ProductViewModel GetById(int id);
        List<ProductViewModel> GetAllProducts();
        bool AddProductImages(List<ProductImage> images);
        bool RemoveProductImage(string path);
        UserOrderGetModel GetOrderProduct(int productId);
    }
}