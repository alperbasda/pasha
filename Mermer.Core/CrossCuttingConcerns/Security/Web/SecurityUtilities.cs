using System;
using System.Linq;
using System.Web.Security;

namespace Mermer.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormAuthToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Name = SetName(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenticated(),
                Roles = SetRoles(ticket),
            };

            return identity;
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        } 

        private bool SetIsAuthenticated()
        {
            return true;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }
    }
}