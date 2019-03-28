namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailInVrijwilliger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vrijwilligers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vrijwilligers", "Email");
        }
    }
}
