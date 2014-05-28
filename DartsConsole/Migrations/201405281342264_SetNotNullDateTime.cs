namespace DartsConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNotNullDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameHeaders", "BeginTimestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameHeaders", "BeginTimestamp", c => c.DateTime());
        }
    }
}
