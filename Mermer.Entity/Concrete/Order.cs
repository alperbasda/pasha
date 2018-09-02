using System;
using Mermer.Core;

namespace Mermer.Entity.Concrete
{
    public enum OrderType
    {
        Tamamlandı,
        Bekliyor
    }

    public class Order : IEntity
    {
        public int Id { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerMail { get; set; }

        public string CustomerTelephone { get; set; }

        public DateTime OrderDate { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public decimal ProductCount { get; set; }

        public OrderType OrderType { get; set; }

        public string OrderDescription { get; set; }


    }
}