namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        EvenementID = c.Int(nullable: false, identity: true),
                        Locatie = c.String(),
                        BeginTijd = c.DateTime(nullable: false),
                        EindTijd = c.DateTime(nullable: false),
                        Restaurant_Keukens = c.String(),
                        EindLocatie = c.String(),
                        Taal = c.String(),
                        Stage = c.String(),
                        Artiest_Naam = c.String(),
                        Artiest_Genre = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EvenementID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Evenements");
        }
    }
}
