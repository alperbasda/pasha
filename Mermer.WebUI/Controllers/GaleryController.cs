using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.Entity.Concrete;

namespace Mermer.WebUI.Controllers
{
    public class GaleryController : Controller
    {
        private IGalleryImageService _galleryImageService;
        public GaleryController(IGalleryImageService galleryImageService)
        {
            _galleryImageService = galleryImageService;
        }
        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult Galery()
        {
            return View(_galleryImageService.GetImages());
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult RemoveImage(int id)
        {
            if (id!=0) _galleryImageService.RemoveImage(id);
            return RedirectToAction("Galery", "Galery");
        }

        [SecuredOperationUi(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase file, string description)
        {
            if (file == null) return RedirectToAction("Galery");
            string path = "/Content/GaleryPhotos/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            file.SaveAs(Server.MapPath(path));
            _galleryImageService.AddImage(new GalleryImage {Description = description,Path = path});

            return RedirectToAction("Galery");
        }

    }
}