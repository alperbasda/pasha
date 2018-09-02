using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult GetAllCategories()
        {
            return View(_categoryService.GetCategories());
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult NewCategory()
        {
            return View();
        }

        [SecuredOperationUi(Roles = "Admin")]
        [HttpPost]
        public ActionResult NewCategory(Category model)
        {
            _categoryService.AddCategory(model);
            return RedirectToAction("GetAllCategories", "Category");
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult EditCategory(int id)
        {
            return View(_categoryService.GetCategoryById(id));
        }

        [SecuredOperationUi(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            _categoryService.UpdateCategory(model);
            return RedirectToAction("GetAllCategories", "Category");
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult RemoveCategory(int id)
        {
            _categoryService.RemoveOrder(id);
            return RedirectToAction("GetAllCategories", "Category");
        }

        
        public JsonResult GetCategoriesJson()
        {
            return Json(_categoryService.GetCategoriesJson(),JsonRequestBehavior.AllowGet);
        }
    }
}