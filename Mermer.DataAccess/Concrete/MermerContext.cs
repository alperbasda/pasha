using System.Data.Entity;
using Mermer.DataAccess.Concrete.Map;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete
{
    public class MermerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get;set; }

        public DbSet<UserInRole> UserInRoles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Site> Sites { get; set; }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        
        public MermerContext()
            :base("MermerDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserInRoleMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductImageMap());
            modelBuilder.Configurations.Add(new SiteMap());
            modelBuilder.Configurations.Add(new GalleryMap());
        }
    }
}