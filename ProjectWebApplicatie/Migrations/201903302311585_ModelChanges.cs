namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evenements", "Dance_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "food_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "History_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "Jazz_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "Events_EventId", "dbo.Events");
            DropIndex("dbo.Evenements", new[] { "Dance_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "food_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "History_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "Jazz_EvenementID" });
            AddColumn("dbo.Evenements", "Events_EventId1", c => c.Int());
            AddColumn("dbo.Evenements", "Events_EventId2", c => c.Int());
            AddColumn("dbo.Evenements", "Events_EventId3", c => c.Int());
            CreateIndex("dbo.Evenements", "Events_EventId1");
            CreateIndex("dbo.Evenements", "Events_EventId2");
            CreateIndex("dbo.Evenements", "Events_EventId3");
            AddForeignKey("dbo.Evenements", "Events_EventId1", "dbo.Events", "EventId");
            AddForeignKey("dbo.Evenements", "Events_EventId2", "dbo.Events", "EventId");
            AddForeignKey("dbo.Evenements", "Events_EventId3", "dbo.Events", "EventId");
            DropColumn("dbo.Evenements", "Dance_EvenementID");
            DropColumn("dbo.Evenements", "food_EvenementID");
            DropColumn("dbo.Evenements", "History_EvenementID");
            DropColumn("dbo.Evenements", "Jazz_EvenementID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "Jazz_EvenementID", c => c.Int());
            AddColumn("dbo.Evenements", "History_EvenementID", c => c.Int());
            AddColumn("dbo.Evenements", "food_EvenementID", c => c.Int());
            AddColumn("dbo.Evenements", "Dance_EvenementID", c => c.Int());
            DropForeignKey("dbo.Evenements", "Events_EventId3", "dbo.Events");
            DropForeignKey("dbo.Evenements", "Events_EventId2", "dbo.Events");
            DropForeignKey("dbo.Evenements", "Events_EventId1", "dbo.Events");
            DropIndex("dbo.Evenements", new[] { "Events_EventId3" });
            DropIndex("dbo.Evenements", new[] { "Events_EventId2" });
            DropIndex("dbo.Evenements", new[] { "Events_EventId1" });
            DropColumn("dbo.Evenements", "Events_EventId3");
            DropColumn("dbo.Evenements", "Events_EventId2");
            DropColumn("dbo.Evenements", "Events_EventId1");
            CreateIndex("dbo.Evenements", "Jazz_EvenementID");
            CreateIndex("dbo.Evenements", "History_EvenementID");
            CreateIndex("dbo.Evenements", "food_EvenementID");
            CreateIndex("dbo.Evenements", "Dance_EvenementID");
            AddForeignKey("dbo.Evenements", "Events_EventId", "dbo.Events", "EventId");
            AddForeignKey("dbo.Evenements", "Jazz_EvenementID", "dbo.Evenements", "EvenementID");
            AddForeignKey("dbo.Evenements", "History_EvenementID", "dbo.Evenements", "EvenementID");
            AddForeignKey("dbo.Evenements", "food_EvenementID", "dbo.Evenements", "EvenementID");
            AddForeignKey("dbo.Evenements", "Dance_EvenementID", "dbo.Evenements", "EvenementID");
        }
    }
}
