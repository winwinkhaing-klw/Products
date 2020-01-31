namespace Product.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Products", "CustomerID");
            AddForeignKey("dbo.Products", "CustomerID", "dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "CustomerID" });
        }
    }
}
