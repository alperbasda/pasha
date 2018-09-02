using System;
using Mermer.Entity.Concrete;

namespace Mermer.Entity.ComplexType
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerMail { get; set; }

        public string CustomerTelephone { get; set; }

        public DateTime OrderDate { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductCount { get; set; }

        public string ProductImagePath { get; set; }

        public string OrderDescription { get; set; }

        public OrderType OrderType { get; set; }
    }
}