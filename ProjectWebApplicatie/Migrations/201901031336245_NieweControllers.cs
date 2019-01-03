namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NieweControllers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "TicketsTotaal", c => c.Int(nullable: false));
            AddColumn("dbo.Evenements", "TicketsVerkocht", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evenements", "TicketsVerkocht");
            DropColumn("dbo.Evenements", "TicketsTotaal");
        }
    }
}
