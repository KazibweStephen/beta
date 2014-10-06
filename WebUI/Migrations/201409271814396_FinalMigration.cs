namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bets", new[] { "MatchId", "SetNo" }, "dbo.Matches");
            DropForeignKey("dbo.MatchOdds", new[] { "GameId", "SetNo" }, "dbo.Matches");
            DropForeignKey("dbo.MatchOdds", "GameId", "dbo.Matches");
            DropForeignKey("dbo.ShortMatchCodes", "MatchNo", "dbo.Matches");
            DropForeignKey("dbo.Bets", "MatchId", "dbo.Matches");
            DropIndex("dbo.Bets", new[] { "MatchId", "SetNo" });
            DropIndex("dbo.MatchOdds", new[] { "GameId", "SetNo" });
            DropPrimaryKey("dbo.Matches");
            CreateTable(
                "dbo.ShortMatchCodes",
                c => new
                    {
                        MatchNo = c.Int(nullable: false),
                        SetNo = c.Int(nullable: false),
                        ShortCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchNo)
                .ForeignKey("dbo.Matches", t => t.MatchNo)
                .Index(t => t.MatchNo);
            
            AddPrimaryKey("dbo.Matches", "MatchNo");
            CreateIndex("dbo.Bets", "MatchId");
            CreateIndex("dbo.MatchOdds", "GameId");
            AddForeignKey("dbo.Bets", "MatchId", "dbo.Matches", "MatchNo", cascadeDelete: true);
            AddForeignKey("dbo.MatchOdds", "GameId", "dbo.Matches", "MatchNo", cascadeDelete: true);
            DropColumn("dbo.Bets", "SetNo");
            DropColumn("dbo.Matches", "SetNo");
            DropColumn("dbo.MatchOdds", "SetNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MatchOdds", "SetNo", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "SetNo", c => c.Int(nullable: false));
            AddColumn("dbo.Bets", "SetNo", c => c.Int(nullable: false));
            DropForeignKey("dbo.MatchOdds", "GameId", "dbo.Matches");
            DropForeignKey("dbo.Bets", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.ShortMatchCodes", "MatchNo", "dbo.Matches");
            DropIndex("dbo.ShortMatchCodes", new[] { "MatchNo" });
            DropIndex("dbo.MatchOdds", new[] { "GameId" });
            DropIndex("dbo.Bets", new[] { "MatchId" });
            DropPrimaryKey("dbo.Matches");
            DropTable("dbo.ShortMatchCodes");
            AddPrimaryKey("dbo.Matches", new[] { "MatchNo", "SetNo" });
            CreateIndex("dbo.MatchOdds", new[] { "GameId", "SetNo" });
            CreateIndex("dbo.Bets", new[] { "MatchId", "SetNo" });
            AddForeignKey("dbo.Bets", "MatchId", "dbo.Matches", "MatchNo", cascadeDelete: true);
            AddForeignKey("dbo.ShortMatchCodes", "MatchNo", "dbo.Matches", "MatchNo");
            AddForeignKey("dbo.MatchOdds", "GameId", "dbo.Matches", "MatchNo", cascadeDelete: true);
            AddForeignKey("dbo.MatchOdds", new[] { "GameId", "SetNo" }, "dbo.Matches", new[] { "MatchNo", "SetNo" }, cascadeDelete: true);
            AddForeignKey("dbo.Bets", new[] { "MatchId", "SetNo" }, "dbo.Matches", new[] { "MatchNo", "SetNo" }, cascadeDelete: true);
        }
    }
}
