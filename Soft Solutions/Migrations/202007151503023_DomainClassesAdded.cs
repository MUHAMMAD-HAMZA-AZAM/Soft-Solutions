namespace Soft_Solutions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainClassesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Details = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CityId", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Cities");
        }
    }
}
