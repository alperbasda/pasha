using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("CategoryId");
            Property(s => s.Name).HasColumnName("CategoryName");
            Property(s => s.ImageUrl).HasColumnName("CategoryImageUrl");
        }
    }
}