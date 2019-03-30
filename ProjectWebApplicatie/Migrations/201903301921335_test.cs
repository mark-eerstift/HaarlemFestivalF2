namespace ProjectWebApplicatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "Dance_EvenementID", c => c.Int());
            AddColumn("dbo.Evenements", "Food_EvenementID", c => c.Int());
            AddColumn("dbo.Evenements", "History_EvenementID", c => c.Int());
            AddColumn("dbo.Evenements", "Jazz_EvenementID", c => c.Int());
            CreateIndex("dbo.Evenements", "Dance_EvenementID");
            CreateIndex("dbo.Evenements", "Food_EvenementID");
            CreateIndex("dbo.Evenements", "History_EvenementID");
            CreateIndex("dbo.Evenements", "Jazz_EvenementID");
            AddForeignKey("dbo.Evenements", "Dance_EvenementID", "dbo.Evenements", "EvenementID");
            AddForeignKey("dbo.Evenements", "Food_EvenementID", "dbo.Evenements", "EvenementID");
            AddForeignKey("dbo.Evenements", "History_EvenementID", "dbo.Evenements", "EvenementID");
            AddForeignKey("dbo.Evenements", "Jazz_EvenementID", "dbo.Evenements", "EvenementID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evenements", "Jazz_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "History_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "Food_EvenementID", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "Dance_EvenementID", "dbo.Evenements");
            DropIndex("dbo.Evenements", new[] { "Jazz_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "History_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "Food_EvenementID" });
            DropIndex("dbo.Evenements", new[] { "Dance_EvenementID" });
            DropColumn("dbo.Evenements", "Jazz_EvenementID");
            DropColumn("dbo.Evenements", "History_EvenementID");
            DropColumn("dbo.Evenements", "Food_EvenementID");
            DropColumn("dbo.Evenements", "Dance_EvenementID");
        }
    }
}
