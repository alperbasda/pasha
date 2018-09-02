using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class UserInRoleMap : EntityTypeConfiguration<UserInRole>
    {
        public UserInRoleMap()
        {
            ToTable(@"UserInRoles", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("UserInRoleId");
            HasRequired(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);
            HasRequired(s => s.Role)
                .WithMany()
                .HasForeignKey(s => s.RoleId);
        }
    }
}