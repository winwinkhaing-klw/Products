namespace Product.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    // Viewmodel migration.
    public partial class Viewmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Products_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Products_Id");
            AddForeignKey("dbo.Customers", "Products_Id", "dbo.Products", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Products_Id", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "Products_Id" });
            DropColumn("dbo.Customers", "Products_Id");
        }
    }
}
