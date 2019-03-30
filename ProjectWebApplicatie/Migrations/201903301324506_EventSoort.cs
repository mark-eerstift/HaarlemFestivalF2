namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventSoort : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "Event_EventId", c => c.Int());
            CreateIndex("dbo.Evenements", "Event_EventId");
            AddForeignKey("dbo.Evenements", "Event_EventId", "dbo.Events", "EventId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evenements", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Evenements", new[] { "Event_EventId" });
            DropColumn("dbo.Evenements", "Event_EventId");
        }
    }
}
