namespace DartsConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginTimestamp = c.DateTime(),
                        EndTimestamp = c.DateTime(),
                        RuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rules", t => t.RuleId, cascadeDelete: true)
                .Index(t => t.RuleId);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sector = c.Int(nullable: false),
                        Factor = c.Int(nullable: false),
                        GameHeaderId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameHeaders", t => t.GameHeaderId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GameHeaderId)
                .Index(t => t.UserId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameLines", "UserId", "dbo.Users");
            DropForeignKey("dbo.GameLines", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.GameLines", "GameHeaderId", "dbo.GameHeaders");
            DropForeignKey("dbo.GameHeaders", "RuleId", "dbo.Rules");
            DropIndex("dbo.GameLines", new[] { "TeamId" });
            DropIndex("dbo.GameLines", new[] { "UserId" });
            DropIndex("dbo.GameLines", new[] { "GameHeaderId" });
            DropIndex("dbo.GameHeaders", new[] { "RuleId" });
            DropTable("dbo.GameLines");
            DropTable("dbo.Rules");
            DropTable("dbo.GameHeaders");
        }
    }
}
