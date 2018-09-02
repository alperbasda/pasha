using System.Collections.Generic;
using System.Linq;
using Mermer.Core.DataAccess.EntityFramework;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete
{
    public class UserDal : EfRepositoryBase<User, MermerContext>,IUserDal
    {
        public List<string> GetUserRoles(User user)
        {
            List<string> result = new List<string>();
            using (MermerContext context = new MermerContext())
            {
                foreach (UserInRole item in context.UserInRoles.Where(s => s.UserId == user.Id).ToList())
                {
                    result.Add(item.Role.Name);
                }

                return result.ToList();
            }
        }
    }
}