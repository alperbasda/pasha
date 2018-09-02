using System.Collections.Generic;
using Mermer.Core.DataAccess;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepositoryBase<User>
    {
        List<string> GetUserRoles(User user);
    }
}