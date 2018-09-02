using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("UserId");
            Property(s => s.Mail).HasColumnName("UserMail");
            Property(s => s.Password).HasColumnName("UserPass");
            Property(s => s.UserName).HasColumnName("UserName");
        }
    }
}