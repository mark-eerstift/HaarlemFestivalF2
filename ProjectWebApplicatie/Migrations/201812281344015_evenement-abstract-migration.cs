namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evenementabstractmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "Restaurant_RestaurantName", c => c.String());
            DropColumn("dbo.Evenements", "Restaurant_Keukens");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "Restaurant_Keukens", c => c.String());
            DropColumn("dbo.Evenements", "Restaurant_RestaurantName");
        }
    }
}
