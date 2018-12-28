namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate28122018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventPages",
                c => new
                    {
                        EventPageID = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.EventPageID)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EventPage_EventPageID = c.Int(),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.EventPages", t => t.EventPage_EventPageID)
                .Index(t => t.EventPage_EventPageID);
            
            AddColumn("dbo.Tickets", "Evenement_EvenementID", c => c.Int());
            CreateIndex("dbo.Tickets", "Evenement_EvenementID");
            AddForeignKey("dbo.Tickets", "Evenement_EvenementID", "dbo.Evenements", "EvenementID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Evenement_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.EventPages", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Images", "EventPage_EventPageID", "dbo.EventPages");
            DropIndex("dbo.Images", new[] { "EventPage_EventPageID" });
            DropIndex("dbo.EventPages", new[] { "Event_EventId" });
            DropIndex("dbo.Tickets", new[] { "Evenement_EvenementID" });
            DropColumn("dbo.Tickets", "Evenement_EvenementID");
            DropTable("dbo.Images");
            DropTable("dbo.EventPages");
        }
    }
}
