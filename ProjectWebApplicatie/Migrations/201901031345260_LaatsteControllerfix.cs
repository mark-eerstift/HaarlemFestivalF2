namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaatsteControllerfix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Evenements", "Stage");
            RenameColumn(table: "dbo.Evenements", name: "Stage1", newName: "Stage");
            AddColumn("dbo.Evenements", "Session", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evenements", "Session");
            RenameColumn(table: "dbo.Evenements", name: "Stage", newName: "Stage1");
            AddColumn("dbo.Evenements", "Stage", c => c.String());
        }
    }
}
