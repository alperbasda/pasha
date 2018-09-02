using Mermer.Core;

namespace Mermer.Entity.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }
}