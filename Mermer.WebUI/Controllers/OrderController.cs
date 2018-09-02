using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult CompletedOrders()
        {
            return View(_orderService.GetComplatedOrders());
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult WaitingOrders()
        {
            return View(_orderService.GetWaitingOrders());
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult RemoveOrder(int id)
        {
            _orderService.RemoveOrder(id);
            return RedirectToAction("Index","Admin");
        }

        [SecuredOperationUi(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditOrder(OrderViewModel model,string completed)
        {
            model.OrderType = completed =="0" ? OrderType.Tamamlandı : OrderType.Bekliyor;
            return _orderService.UpdateOrder(model) ? RedirectToAction("CompletedOrders", "Order") : RedirectToAction("DetailOrder", "Order", new { id = model.Id });
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult NewOrder()
        {
            return View();
        }

        [SecuredOperationUi(Roles = "Admin")]
        [HttpPost]
        public ActionResult NewOrder(OrderViewModel model)
        {
            if (_orderService.AddOrder(model))
                return RedirectToAction("WaitingOrders","Order");
            return RedirectToAction("Error", "Admin", new {error= "Sipariş eklenirken hata oluştu!!!!"});
        }

        [SecuredOperationUi(Roles = "Admin")]
        public ActionResult DetailOrder(int id)
        {
            return View(_orderService.GetOrderById(id));
        }
    }
}