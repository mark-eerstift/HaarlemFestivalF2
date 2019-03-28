namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaltToVrijwilligerTabel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vrijwilligers", "salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vrijwilligers", "salt");
        }
    }
}
