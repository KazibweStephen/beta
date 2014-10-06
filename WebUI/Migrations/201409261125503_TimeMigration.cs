namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "SetSize", c => c.Int(nullable: false));
            AddColumn("dbo.Receipts", "SubmitedSize", c => c.Int(nullable: false));
            AddColumn("dbo.Receipts", "WonSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "WonSize");
            DropColumn("dbo.Receipts", "SubmitedSize");
            DropColumn("dbo.Receipts", "SetSize");
        }
    }
}
