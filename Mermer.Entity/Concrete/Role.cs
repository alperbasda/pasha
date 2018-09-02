using Mermer.Core;

namespace Mermer.Entity.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}