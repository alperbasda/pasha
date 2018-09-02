using System.Collections.Generic;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Concrete.Managers
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public List<OrderViewModel> GetComplatedOrders()
        {
            return _orderDal.GetFilteredOrder(OrderType.Tamamlandı);
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public List<OrderViewModel> GetWaitingOrders()
        {
            return _orderDal.GetFilteredOrder(OrderType.Bekliyor);
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public bool AddOrder(OrderViewModel model)
        {
            return _orderDal.AddOrder(model);
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public OrderViewModel GetOrderById(int id)
        {
            return _orderDal.GetOrderById(id);
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public bool UpdateOrder(OrderViewModel model)
        {
            return _orderDal.UpdateOrder(model);
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public void RemoveOrder(int id)
        {
            _orderDal.Delete(_orderDal.Get(s => s.Id == id));
        }

        public bool AddUserOrder(UserOrderSetModel model)
        {
            return _orderDal.AddUserOrder(model);
        }
    }
}