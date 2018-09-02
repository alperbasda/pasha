using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.Entity.Concrete;

namespace Mermer.WebUI.Controllers
{
    public class SiteController : Controller
    {
        private ISiteService _siteService;
        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(_siteService.GetBasicData());
        }
        

        [HttpPost]
        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult EditSite(Site site)
        {
            _siteService.EditBasicData(site);
            return RedirectToAction("Index", "Admin");
        }

        


    }
}