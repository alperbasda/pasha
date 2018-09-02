using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable(@"Orders", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("OrderId");
            Property(s => s.CustomerFirstName).HasColumnName("CustomerName");
            Property(s => s.CustomerLastName).HasColumnName("CustomerSurName");
            Property(s => s.CustomerMail).HasColumnName("CustomerMailAddress");
            Property(s => s.CustomerTelephone).HasColumnName("CustomerTelephoneNumber");
            Property(s => s.OrderDate).HasColumnName("OrderDate");
            Property(s => s.ProductCount).HasColumnName("SoldProductCount");
            Property(s => s.OrderDescription).HasColumnName("OrderDescription");
            Property(s => s.OrderType).HasColumnName("OrderType");
            HasRequired(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId);
        }
    }
}