using Mermer.Core.DataAccess.EntityFramework;
using Mermer.DataAccess.Abstract;
using Mermer.DataAccess.Helpers.AdminIndexBuilder;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete
{
    public class SiteDal : EfRepositoryBase<Site,MermerContext>, ISiteDal
    {
        public IndexViewModel GetIndexPage()
        {
            using (MermerContext context = new MermerContext())
            {
                IndexBuilder builder = new IndexBuilder(context);
                return builder.SetCompletedOrderCount().SetProductCount().SetWaitingOrderCount().SetTotalInCome().SetWaitingOrders().BuildModel();
            }
        }

        
    }
}