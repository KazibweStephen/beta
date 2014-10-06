namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addodds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bets", "GameBetStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bets", "GameBetStatus");
        }
    }
}
