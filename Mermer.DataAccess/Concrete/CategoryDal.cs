using System.Linq;
using Mermer.Core.DataAccess.EntityFramework;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.Concrete;
using System.Web.Script.Serialization;

namespace Mermer.DataAccess.Concrete
{
    public class CategoryDal : EfRepositoryBase<Category,MermerContext>,ICategoryDal
    {
        public string GetCategoriesJson()
        {
            using (MermerContext context = new MermerContext())
            {
                return new JavaScriptSerializer().Serialize(context.Categories.ToList());
            }
        }
    }
}