using System.Collections.Generic;
using Mermer.Entity.ComplexType;

namespace Mermer.Business.Abstract
{
    public interface IOrderService
    {
        List<OrderViewModel> GetComplatedOrders();
        List<OrderViewModel> GetWaitingOrders();
        bool AddOrder(OrderViewModel model);
        OrderViewModel GetOrderById(int id);
        bool UpdateOrder(OrderViewModel model);
        void RemoveOrder(int id);
        bool AddUserOrder(UserOrderSetModel model);

    }

}