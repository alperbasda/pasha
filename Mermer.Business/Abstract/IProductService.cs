using System.Collections.Generic;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Abstract
{
    public interface IProductService
    {
        string GetProductInFilteredCategory(int id);
        ProductViewModel GetById(int id);
        List<ProductViewModel> GetAllProducts();
        void RemoveProduct(int id);
        int AddProduct(Product product);
        int EditProduct(Product product);
        bool AddProductImage(int productId,string[] images,string[] imageDesc);
        bool RemoveProductImage(string path);
        UserOrderGetModel GetOrderProduct(int productId);
        bool SetProductDefaultValue(int categoryId,int productId,string productName,string productDescription);
    }
}