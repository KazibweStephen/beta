namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pat1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "SetSize", c => c.Int(nullable: false));
            AddColumn("dbo.Receipts", "SubmitedSize", c => c.Int(nullable: false));
            AddColumn("dbo.Receipts", "WonSize", c => c.Int(nullable: false));
            AddColumn("dbo.Branches", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Bets", "GameBetStatus", c => c.Int(nullable: false));
            AddColumn("dbo.MatchOdds", "HandicapGoals", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MatchOdds", "HandicapGoals");
            DropColumn("dbo.Bets", "GameBetStatus");
            DropColumn("dbo.Branches", "Balance");
            DropColumn("dbo.Receipts", "WonSize");
            DropColumn("dbo.Receipts", "SubmitedSize");
            DropColumn("dbo.Receipts", "SetSize");
        }
    }
}
