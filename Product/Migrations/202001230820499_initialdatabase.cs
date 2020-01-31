namespace Product.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// initialdatabase migration for products table.
    /// </summary>
    public partial class Initialdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
