using System.Collections.Generic;
using System.IO;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.DataAccess.Abstract;
using Mermer.DataAccess.Concrete;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public string GetProductInFilteredCategory(int id)
        {
            return _productDal.GetProductsInCategory(id);
        }


        public ProductViewModel GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public void RemoveProduct(int id)
        {
            _productDal.Delete(_productDal.Get(s => s.Id == id));
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public int AddProduct(Product product)
        {
            Product p = _productDal.Get(s =>
                s.CategoryId == product.CategoryId & s.Name == product.Name & s.Description == product.Description);

            return p != null ? p.Id : _productDal.Add(product).Id;
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public int EditProduct(Product product)
        {
            return _productDal.Update(product).Id;
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public bool AddProductImage(int productId, string[] images, string[] imageDesc)
        {
            List<ProductImage> sendImage = new List<ProductImage>();
            for (int i = 0; i < images.Length; i++)
                sendImage.Add(new ProductImage { ImagePath = images[i], ProductId = productId, ImageDescription = imageDesc[i] });

            return _productDal.AddProductImages(sendImage);

        }

        [SecuredOperationAspect(Roles = "Admin")]
        public bool RemoveProductImage(string path)
        {
            return _productDal.RemoveProductImage(path);
        }

        public UserOrderGetModel GetOrderProduct(int productId)
        {
            return _productDal.GetOrderProduct(productId);
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public bool SetProductDefaultValue(int categoryId, int productId, string productName, string productDescription)
        {
            Product p = _productDal.Get(s=>s.Id==productId);
            if (p == null)
                return false;
            p.CategoryId = categoryId;
            p.Description = productDescription;
            p.Name = productName;
            _productDal.Update(p);
            return true;
        }
        
    }
}