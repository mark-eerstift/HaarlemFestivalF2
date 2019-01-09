namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prijs_keukenstijl_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "EvenementPrijs", c => c.Double(nullable: false));
            AddColumn("dbo.Evenements", "Restaurant_Keukens", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evenements", "Restaurant_Keukens");
            DropColumn("dbo.Evenements", "EvenementPrijs");
        }
    }
}
