namespace DartsConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addfieldsforcommandplay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameHeaders", "WinnerId", c => c.Int());
            AddColumn("dbo.Rules", "IsCommand", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rules", "IsCommand");
            DropColumn("dbo.GameHeaders", "WinnerId");
        }
    }
}
