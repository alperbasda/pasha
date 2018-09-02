using System.Security.Principal;

namespace Mermer.Core.CrossCuttingConcerns.Security
{
    public class Identity : IIdentity
    {
        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string[] Roles { get; set; }

    }
}