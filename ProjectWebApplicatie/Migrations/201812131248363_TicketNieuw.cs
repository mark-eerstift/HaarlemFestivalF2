namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketNieuw : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Prijs = c.Single(nullable: false),
                        SaleStatus = c.Boolean(nullable: false),
                        Date = c.DateTime(),
                        Notitie = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "Event_EventId" });
            DropTable("dbo.Tickets");
        }
    }
}
