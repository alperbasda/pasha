using System.Collections.Generic;
using Mermer.Entity.Concrete;

namespace Mermer.Entity.ComplexType
{
    public class UserOrderSetModel
    {
        public int Id { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerMail { get; set; }

        public string CustomerTelephone { get; set; }

        public string OrderDescription { get; set; }

        public decimal ProductCount { get; set; }

        public int ProductId { get; set; }

        
    }
}