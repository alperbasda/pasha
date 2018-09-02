using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Name).HasColumnName("ProductName");
            Property(s => s.Description).HasColumnName("ProductDescription");
            HasRequired(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.CategoryId);
        }
    }
}