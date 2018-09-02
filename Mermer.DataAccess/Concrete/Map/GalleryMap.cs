using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class GalleryMap : EntityTypeConfiguration<GalleryImage>
    {
        public GalleryMap()
        {
            ToTable(@"GalleryImages", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("Id");
            Property(s => s.Description).HasColumnName("ImageDescription");
            Property(s => s.Path).HasColumnName("ImagePath");
        }
    }
}