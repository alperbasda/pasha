namespace Mermer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.GalleryImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ImageDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerSurName = c.String(),
                        CustomerMailAddress = c.String(),
                        CustomerTelephoneNumber = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        SoldProductCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderType = c.Int(nullable: false),
                        OrderDescription = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductImageDescription = c.String(),
                        ProductImagePath = c.String(),
                        IsProfileImage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteId = c.Int(nullable: false, identity: true),
                        SiteVision = c.String(),
                        SiteMainArticleTitle = c.String(),
                        SiteMainArticle = c.String(),
                        SiteMission = c.String(),
                        SiteAbout = c.String(),
                        SiteAddress = c.String(),
                        SiteTelephone = c.String(),
                        SiteMail = c.String(),
                    })
                .PrimaryKey(t => t.SiteId);
            
            CreateTable(
                "dbo.UserInRoles",
                c => new
                    {
                        UserInRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserInRoleId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserMail = c.String(),
                        UserPass = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserInRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserInRoles", new[] { "RoleId" });
            DropIndex("dbo.UserInRoles", new[] { "UserId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserInRoles");
            DropTable("dbo.Sites");
            DropTable("dbo.Roles");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.GalleryImages");
            DropTable("dbo.Categories");
        }
    }
}
