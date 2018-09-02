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
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            _userService.Login(model);
            return RedirectToAction("Index","Admin");
        }
        public ActionResult SignOut()
        {
            _userService.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Account");
        }
        
    }
}