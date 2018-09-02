using Mermer.Core.DataAccess;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Abstract
{
    public interface ISiteDal : IEntityRepositoryBase<Site>
    {
        IndexViewModel GetIndexPage();

    }
}