namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wijziging : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Evenements", name: "Event_EventId", newName: "Events_EventId");
            RenameIndex(table: "dbo.Evenements", name: "IX_Event_EventId", newName: "IX_Events_EventId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Evenements", name: "IX_Events_EventId", newName: "IX_Event_EventId");
            RenameColumn(table: "dbo.Evenements", name: "Events_EventId", newName: "Event_EventId");
        }
    }
}
