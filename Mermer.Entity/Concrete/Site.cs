using Mermer.Core;

namespace Mermer.Entity.Concrete
{
    public class Site : IEntity
    {
        public int Id { get; set; }

        public string Vision { get; set; }

        public string MainArticleTitle { get; set; }

        public string MainArticle { get; set; }

        public string Mission { get; set; }

        public string About { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Mail { get; set; }
    }
}