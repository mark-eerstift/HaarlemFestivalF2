namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        EvenementID = c.Int(nullable: false, identity: true),
                        Locatie = c.String(),
                        BeginTijd = c.DateTime(nullable: false),
                        EindTijd = c.DateTime(nullable: false),
                        TicketsTotaal = c.Int(nullable: false),
                        TicketsVerkocht = c.Int(nullable: false),
                        EvenementPrijs = c.Double(nullable: false),
                        Session = c.String(),
                        Artiest_Naam = c.String(),
                        Artiest_Genre = c.String(),
                        Restaurant_RestaurantName = c.String(),
                        Restaurant_Keukens = c.String(),
                        EindLocatie = c.String(),
                        Taal = c.String(),
                        Stage = c.String(),
                        Artiest_Naam1 = c.String(),
                        Artiest_Genre1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Dance_EvenementID = c.Int(),
                        Events_EventId = c.Int(),
                        food_EvenementID = c.Int(),
                        History_EvenementID = c.Int(),
                        Jazz_EvenementID = c.Int(),
                    })
                .PrimaryKey(t => t.EvenementID)
                .ForeignKey("dbo.Evenements", t => t.Dance_EvenementID)
                .ForeignKey("dbo.Events", t => t.Events_EventId)
                .ForeignKey("dbo.Evenements", t => t.food_EvenementID)
                .ForeignKey("dbo.Evenements", t => t.History_EvenementID)
                .ForeignKey("dbo.Evenements", t => t.Jazz_EvenementID)
                .Index(t => t.Dance_EvenementID)
                .Index(t => t.Events_EventId)
                .Index(t => t.food_EvenementID)
                .Index(t => t.History_EvenementID)
                .Index(t => t.Jazz_EvenementID);
            
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
                        Evenement_EvenementID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .ForeignKey("dbo.Evenements", t => t.Evenement_EvenementID)
                .Index(t => t.Event_EventId)
                .Index(t => t.Evenement_EvenementID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventSoort = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
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
            
            CreateTable(
                "dbo.Vrijwilligers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Wachtwoord = c.String(),
                        salt = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evenements", "Jazz_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "History_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "food_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "Events_EventId", "dbo.Events");
            DropForeignKey("dbo.Evenements", "Dance_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Tickets", "Evenement_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Tickets", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.EventPages", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Images", "EventPage_EventPageID", "dbo.EventPages");
            DropIndex("dbo.Images", new[] { "EventPage_EventPageID" });
            DropIndex("dbo.EventPages", new[] { "Event_EventId" });
            DropIndex("dbo.Tickets", new[] { "Evenement_EvenementID" });
            DropIndex("dbo.Tickets", new[] { "Event_EventId" });
            DropIndex("dbo.Evenements", new[] { "Jazz_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "History_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "food_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "Events_EventId" });
            DropIndex("dbo.Evenements", new[] { "Dance_EvenementID" });
            DropTable("dbo.Vrijwilligers");
            DropTable("dbo.Images");
            DropTable("dbo.EventPages");
            DropTable("dbo.Events");
            DropTable("dbo.Tickets");
            DropTable("dbo.Evenements");
        }
    }
}
