namespace DartsConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addisbustcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameLines", "IsBust", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameLines", "IsBust");
        }
    }
}
