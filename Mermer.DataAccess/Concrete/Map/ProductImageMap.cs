using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class ProductImageMap : EntityTypeConfiguration<ProductImage>
    {
        public ProductImageMap()
        {
            ToTable(@"ProductImages", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("ProductImageId");
            Property(s => s.ImagePath).HasColumnName("ProductImagePath");
            Property(s => s.IsFirst).HasColumnName("IsProfileImage");
            Property(s => s.ImageDescription).HasColumnName("ProductImageDescription");
            HasRequired(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId);
        }
    }
}