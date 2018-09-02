using Mermer.Core.DataAccess;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepositoryBase<Category>
    {
        string GetCategoriesJson();
    }
}