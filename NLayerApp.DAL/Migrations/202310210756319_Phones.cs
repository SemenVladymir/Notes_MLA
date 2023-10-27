namespace NLayerApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        PhoneId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Phones", t => t.PhoneId, cascadeDelete: true)
                .Index(t => t.PhoneId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Company = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PhoneId", "dbo.Phones");
            DropIndex("dbo.Orders", new[] { "PhoneId" });
            DropTable("dbo.Phones");
            DropTable("dbo.Orders");
        }
    }
}
