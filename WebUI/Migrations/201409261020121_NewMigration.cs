namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receipts", "UserId", "dbo.AspNetUsers");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.Receipts", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
