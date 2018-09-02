using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Mermer.Core.DataAccess.EntityFramework;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete
{
    public class ProductDal : EfRepositoryBase<Product, MermerContext>, IProductDal
    {
        public string GetProductsInCategory(int id)
        {
            using (MermerContext context = new MermerContext())
            {
                List<ProductViewModel> model = new List<ProductViewModel>();
                foreach (var product in context.Products.Where(s => s.CategoryId == id))
                {
                    model.Add(ClassChangeSerializeable(product, context));
                }
                return new JavaScriptSerializer().Serialize(model);
            }
        }
        

        public ProductViewModel GetById(int id)
        {
            using (MermerContext context = new MermerContext())
            {
                return ClassChange(context.Products.FirstOrDefault(s => s.Id == id), context); ;
            }
        }

        public List<ProductViewModel> GetAllProducts()
        {
            using (MermerContext context = new MermerContext())
            {
                List<ProductViewModel> model = new List<ProductViewModel>();
                foreach (var product in context.Products.ToList())
                {
                    model.Add(ClassChange(product, context));
                }
                return model;
            }
        }

        public bool AddProductImages(List<ProductImage> images)
        {
            using (MermerContext context = new MermerContext())
            {
                foreach (var image in images)
                {
                    context.ProductImages.Add(image);
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool RemoveProductImage(string path)
        {
            using (MermerContext context = new MermerContext())
            {
                context.ProductImages.Remove(context.ProductImages.First(s => s.ImagePath == path));
                context.SaveChanges();
                return true;
            }
        }

        public UserOrderGetModel GetOrderProduct(int productId)
        {
            using (MermerContext context = new MermerContext())
            {
                Product p = context.Products.FirstOrDefault(s => s.Id == productId);
                List<ProductImageViewModel> list = new List<ProductImageViewModel>();
                
                return new UserOrderGetModel
                {
                    ProductId = productId,
                    ProductName = p.Name,
                    ProductImages = list,
                    Description = p.Description,
                };

            }
        }
        
        
        public ProductViewModel ClassChange(Product product, MermerContext context)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Images = context.ProductImages.Where(s => s.ProductId == product.Id).Select(s => new ProductImageViewModel { Path = s.ImagePath }).ToList(),
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                
            };
        }

        public ProductViewModel ClassChangeSerializeable(Product product, MermerContext context)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,

            };
        }
    }
}