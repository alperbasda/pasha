using System.Linq;
using Mermer.DataAccess.Concrete;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Helpers.AdminIndexBuilder
{
    public class IndexBuilder
    {
        private readonly MermerContext _context;
        private IndexViewModel _model;
        public IndexBuilder(MermerContext context)
        {
            _model = new IndexViewModel();
            _context = context;
        }

        public IndexBuilder SetProductCount()
        {
            _model.ProductCount = _context.Products.Count();
            return this;
        }

        public IndexBuilder SetWaitingOrderCount()
        {
            _model.WaitingOrdersCount = _context.Orders.Count(s => s.OrderType == OrderType.Bekliyor);
            return this;
        }

        public IndexBuilder SetCompletedOrderCount()
        {
            _model.CompletedOrdersCount = _context.Orders.Count(s => s.OrderType == OrderType.Tamamlandı);
            return this;
        }

        public IndexBuilder SetWaitingOrders()
        {
            _model.WaitingOrders = _context.Orders.Where(s => s.OrderType == OrderType.Bekliyor).Select(s => new OrderViewModel
            {
                Id=s.Id,
                CustomerFirstName= s.CustomerFirstName,
                CustomerLastName = s.CustomerLastName,
                OrderDescription = s.OrderDescription,
                OrderDate = s.OrderDate
            }).ToList();
            return this;
        }

        public IndexBuilder SetTotalInCome()
        {
            _model.TotalInCome =0;

            return this;
        }

        public IndexViewModel BuildModel()
        {
            return _model;
        }
    }
}