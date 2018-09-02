using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Mermer.Core.DataAccess.EntityFramework;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete
{
    public class OrderDal : EfRepositoryBase<Order, MermerContext>, IOrderDal
    {
        public List<OrderViewModel> GetFilteredOrder(OrderType type)
        {
            using (MermerContext context = new MermerContext())
            {
                return GetViewModel(context.Orders.Where(s => s.OrderType == type).ToList());
            }
        }

        public bool AddOrder(OrderViewModel model)
        {
            using (MermerContext context = new MermerContext())
            {
                context.Orders.Add(new Order
                {
                    CustomerFirstName = model.CustomerFirstName,
                    CustomerLastName = model.CustomerLastName,
                    CustomerMail = model.CustomerMail,
                    CustomerTelephone = model.CustomerTelephone,
                    OrderDate = DateTime.Now,
                    OrderDescription = model.OrderDescription,
                    OrderType = OrderType.Bekliyor,
                    ProductCount = model.ProductCount,
                    ProductId = model.ProductId
                });
                context.SaveChanges();
            }

            return true;
        }

        public OrderViewModel GetOrderById(int id)
        {
            using (MermerContext context = new MermerContext())
            {
                try
                {
                    return GetViewModel(context.Orders.Where(s => s.Id == id).ToList()).First();

                }
                catch (Exception e)
                {
                    return GetViewModel(context.Orders.Where(s => s.Id == 1).ToList()).First();
                }
            }
        }

        public bool UpdateOrder(OrderViewModel model)
        {

            using (MermerContext context = new MermerContext())
            {
                Order o = context.Orders.SingleOrDefault(s => s.Id == model.Id);
                if (o != null)
                {
                    o.CustomerFirstName = model.CustomerFirstName;
                    o.CustomerLastName = model.CustomerLastName;
                    o.CustomerMail = model.CustomerMail;
                    o.CustomerTelephone = model.CustomerTelephone;
                    o.OrderDescription = model.OrderDescription;
                    o.OrderType = model.OrderType;
                    o.ProductCount = model.ProductCount;
                    o.ProductId = model.ProductId;
                }
                context.SaveChanges();
            }

            return true;
        }

        public bool AddUserOrder(UserOrderSetModel model)
        {
            using (MermerContext context = new MermerContext())
            {
                try
                {

                    var relation = context.Products.FirstOrDefault(s => s.Id == model.ProductId);
                    context.Orders.Add(new Order
                    {
                        CustomerFirstName = model.CustomerFirstName,
                        CustomerLastName = model.CustomerLastName,
                        CustomerMail = model.CustomerMail,
                        CustomerTelephone = model.CustomerTelephone,
                        OrderDate = DateTime.Now,
                        OrderDescription = model.OrderDescription,
                        OrderType = OrderType.Bekliyor,
                        ProductCount = model.ProductCount,
                        ProductId = relation.Id
                    });
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return true;
        }


        private List<OrderViewModel> GetViewModel(List<Order> fullList)
        {
            return fullList.Select(s => new OrderViewModel
            {
                Id = s.Id,
                OrderType = s.OrderType,
                CustomerFirstName = s.CustomerFirstName,
                CustomerLastName = s.CustomerLastName,
                ProductCount = s.ProductCount,
                ProductId = s.Product.Id,
                OrderDescription = s.OrderDescription,
                CustomerTelephone = s.CustomerTelephone,
                OrderDate = s.OrderDate,
                CustomerMail = s.CustomerMail,
                ProductName = s.Product.Name,
            }).ToList();

        }
    }
}