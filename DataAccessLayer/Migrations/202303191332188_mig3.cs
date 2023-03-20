namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "CatagoryID", "dbo.Catagories");
            DropIndex("dbo.Headings", new[] { "CatagoryID" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryDescription = c.String(maxLength: 200),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            AddColumn("dbo.Headings", "CategoryID", c => c.Int());
            CreateIndex("dbo.Headings", "CategoryID");
            AddForeignKey("dbo.Headings", "CategoryID", "dbo.Categories", "CategoryID");
            DropColumn("dbo.Headings", "CatagoryID");
            DropTable("dbo.Catagories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        CatagoryID = c.Int(nullable: false, identity: true),
                        CatagoryName = c.String(maxLength: 50),
                        CatagoryDescription = c.String(maxLength: 200),
                        CatagoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CatagoryID);
            
            AddColumn("dbo.Headings", "CatagoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Headings", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Headings", new[] { "CategoryID" });
            DropColumn("dbo.Headings", "CategoryID");
            DropTable("dbo.Categories");
            CreateIndex("dbo.Headings", "CatagoryID");
            AddForeignKey("dbo.Headings", "CatagoryID", "dbo.Catagories", "CatagoryID", cascadeDelete: true);
        }
    }
}
