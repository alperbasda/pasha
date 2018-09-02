using System.Collections.Generic;

namespace Mermer.Entity.ComplexType
{
    public class IndexViewModel
    {
        public int ProductCount { get; set; }

        public int WaitingOrdersCount { get; set; }

        public int CompletedOrdersCount { get; set; }

        public decimal TotalInCome { get; set; }

        public List<OrderViewModel> WaitingOrders { get; set; }
    }
}