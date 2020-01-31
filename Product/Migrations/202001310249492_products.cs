namespace Product.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class products : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Products_Id", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "Products_Id" });
            DropColumn("dbo.Customers", "Products_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Customers", "Products_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Products_Id");
            AddForeignKey("dbo.Customers", "Products_Id", "dbo.Products", "Id");
        }
    }
}
