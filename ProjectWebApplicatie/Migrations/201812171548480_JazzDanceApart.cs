namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JazzDanceApart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "Stage1", c => c.String());
            AddColumn("dbo.Evenements", "Artiest_Naam1", c => c.String());
            AddColumn("dbo.Evenements", "Artiest_Genre1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evenements", "Artiest_Genre1");
            DropColumn("dbo.Evenements", "Artiest_Naam1");
            DropColumn("dbo.Evenements", "Stage1");
        }
    }
}
