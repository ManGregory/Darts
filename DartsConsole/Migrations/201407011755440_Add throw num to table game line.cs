namespace DartsConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addthrownumtotablegameline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameLines", "ThrowNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameLines", "ThrowNum");
        }
    }
}
