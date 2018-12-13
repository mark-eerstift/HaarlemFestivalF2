namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        eventSoort = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            DropTable("dbo.Tickets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Prijs = c.Single(nullable: false),
                        SaleStatus = c.Boolean(nullable: false),
                        Date = c.DateTime(),
                        Notitie = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID);
            
            DropTable("dbo.Events");
        }
    }
}
