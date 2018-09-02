using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Mermer.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(string userName, string mail, string[] roles, DateTime expiration, bool rememberMe)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe, CreateAuthText(mail, roles));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }
        private static string CreateAuthText(string mail, string[] roles)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(mail);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (i < roles.Length - 1)
                    stringBuilder.Append(",");
            }
            stringBuilder.Append("|");
            return stringBuilder.ToString();
        }

    }
}