namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bets", "Odd", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bets", "Odd");
        }
    }
}
