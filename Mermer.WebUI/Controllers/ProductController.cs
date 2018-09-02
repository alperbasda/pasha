using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;
using Microsoft.JScript;

namespace Mermer.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult GetAllProducts()
        {
            return View(_productService.GetAllProducts());
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult AddNewProduct(Product product)
        {
            _productService.AddProduct(product);
            return RedirectToAction("GetAllProducts");
        }
        
        [SecuredOperationUi(Roles = "Admin")]
        public JsonResult AddProductJson(Product product)
        {
            return Json(_productService.AddProduct(product), JsonRequestBehavior.AllowGet);
        }
        [SecuredOperationUi(Roles = "Admin")]
        public JsonResult AddProductImageJson(int productId, string images, string imagesDesc)
        {
            if (images.Length>3)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return Json(_productService.AddProductImage(productId, serializer.Deserialize<string[]>(images), serializer.Deserialize<string[]>(imagesDesc)), JsonRequestBehavior.AllowGet);

            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        
        [SecuredOperationUi(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditProduct(ProductViewModel model)
        {

            return RedirectToAction("DetailProduct","Product",new {id=model.Id});
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult RemoveProduct(int id)
        {
            _productService.RemoveProduct(id);
            return RedirectToAction("GetAllProducts", "Product");
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult DetailProduct(int id)
        {
            return View(_productService.GetById(id));
        }

        [SecuredOperationUi(Roles = "Admin")]
        public JsonResult GetProductsInCategoryJson(int id)
        {
            return Json(_productService.GetProductInFilteredCategory(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [SecuredOperationUi(Roles = "Admin")]
        public JsonResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (true)
                {
                    string path = "/Content/ProductPhotos/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(path));
                    string[] turn = { file.FileName, path };
                    return Json(turn, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        [SecuredOperationUi(Roles = "Admin")]
        public JsonResult RemoveImage(string path)
        {
            if (path=="")
            return Json(0, JsonRequestBehavior.AllowGet);
            _productService.RemoveProductImage(path);
            var filePath = Server.MapPath(path);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            return Json(1, JsonRequestBehavior.AllowGet);

        }
        
        [SecuredOperationUi(Roles = "Admin")]
        public JsonResult SetDefaultValueJson(int categoryId,int productId,string productName,string productDescription)
        {
            return Json(_productService.SetProductDefaultValue(categoryId, productId, productName, productDescription), JsonRequestBehavior.AllowGet);
        }


    }
}