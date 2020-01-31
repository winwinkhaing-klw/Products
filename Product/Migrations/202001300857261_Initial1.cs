namespace Product.Migrations
{
    using System;
    using System.Data.Entity.Migrations;  

    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CustomerID", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("dbo.Products", "CustomerID");
        }
    }
}
