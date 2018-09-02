using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Mermer.Core;

namespace Mermer.Entity.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        

    }
}