using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable(@"Roles", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("RoleId");
            Property(s => s.Name).HasColumnName("RoleName");
        }
    }
}