using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Mermer.Business.DepandencyResolvers;
using Mermer.Core.CrossCuttingConcerns.Security.Web;
using Mermer.Core.Utilities.Mvc.Infrastructure;

namespace Mermer.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }
        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }
                var encTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encTicket))
                {
                    return;
                }
                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormAuthToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch
            {

            }


        }
    }
}
