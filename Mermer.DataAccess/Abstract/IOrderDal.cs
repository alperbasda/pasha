using System.Collections.Generic;
using Mermer.Core.DataAccess;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepositoryBase<Order>
    {
        List<OrderViewModel> GetFilteredOrder(OrderType type);
        bool AddOrder(OrderViewModel model);
        OrderViewModel GetOrderById(int id);
        bool UpdateOrder(OrderViewModel model);
        bool AddUserOrder(UserOrderSetModel model);
    }
}