using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.Entity.ComplexType;

namespace Mermer.WebUI.Controllers
{
    [SecuredOperationUi(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ISiteService _siteService;
        public AdminController(ISiteService siteService)
        {
            _siteService = siteService;
        }
        public ActionResult Index()
        {
            return View(_siteService.IndexPageCalculate());
        }

        public ActionResult Error(string error)
        {
            ViewBag.Error = error;
            return View();
        }
    }
}