namespace DartsConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNullableForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameLines", "TeamId", "dbo.Teams");
            DropIndex("dbo.GameLines", new[] { "TeamId" });
            AlterColumn("dbo.GameLines", "TeamId", c => c.Int());
            CreateIndex("dbo.GameLines", "TeamId");
            AddForeignKey("dbo.GameLines", "TeamId", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameLines", "TeamId", "dbo.Teams");
            DropIndex("dbo.GameLines", new[] { "TeamId" });
            AlterColumn("dbo.GameLines", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.GameLines", "TeamId");
            AddForeignKey("dbo.GameLines", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
    }
}
