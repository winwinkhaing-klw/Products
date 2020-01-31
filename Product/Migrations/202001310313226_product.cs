namespace Product.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        Customers_CustomerID = c.Int(),
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customers_CustomerID)
                .ForeignKey("dbo.Products", t => t.Products_Id)
                .Index(t => t.Customers_CustomerID)
                .Index(t => t.Products_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductViewModels", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.ProductViewModels", "Customers_CustomerID", "dbo.Customers");
            DropIndex("dbo.ProductViewModels", new[] { "Products_Id" });
            DropIndex("dbo.ProductViewModels", new[] { "Customers_CustomerID" });
            DropTable("dbo.ProductViewModels");
        }
    }
}
