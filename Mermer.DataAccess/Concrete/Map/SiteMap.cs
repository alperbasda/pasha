using System.Data.Entity.ModelConfiguration;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete.Map
{
    public class SiteMap : EntityTypeConfiguration<Site>
    {
        public SiteMap()
        {
            ToTable(@"Sites", @"dbo");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("SiteId");
            Property(s => s.About).HasColumnName("SiteAbout");
            Property(s => s.Address).HasColumnName("SiteAddress");
            Property(s => s.Telephone).HasColumnName("SiteTelephone");
            Property(s => s.Mail).HasColumnName("SiteMail");
            Property(s => s.Mission).HasColumnName("SiteMission");
            Property(s => s.Vision).HasColumnName("SiteVision");
            Property(s => s.MainArticle).HasColumnName("SiteMainArticle");
            Property(s => s.MainArticleTitle).HasColumnName("SiteMainArticleTitle");
        }
    }
}