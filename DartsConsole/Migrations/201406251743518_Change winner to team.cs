namespace DartsConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changewinnertoteam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameHeaders", "TeamWinnerId", c => c.Int());
            CreateIndex("dbo.GameHeaders", "TeamWinnerId");
            AddForeignKey("dbo.GameHeaders", "TeamWinnerId", "dbo.Teams", "Id");
            DropColumn("dbo.GameHeaders", "WinnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameHeaders", "WinnerId", c => c.Int());
            DropForeignKey("dbo.GameHeaders", "TeamWinnerId", "dbo.Teams");
            DropIndex("dbo.GameHeaders", new[] { "TeamWinnerId" });
            DropColumn("dbo.GameHeaders", "TeamWinnerId");
        }
    }
}
