namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lasttest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receipts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bets", "RecieptId", "dbo.Receipts");
            DropForeignKey("dbo.CancelReciepts", "RecieptId", "dbo.Receipts");
            DropPrimaryKey("dbo.Receipts");
            AddColumn("dbo.Receipts", "Serial", c => c.Guid());
            AlterColumn("dbo.Receipts", "ReceiptId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Receipts", "ReceiptId");
            AddForeignKey("dbo.Bets", "RecieptId", "dbo.Receipts", "ReceiptId", cascadeDelete: true);
            AddForeignKey("dbo.CancelReciepts", "RecieptId", "dbo.Receipts", "ReceiptId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CancelReciepts", "RecieptId", "dbo.Receipts");
            DropForeignKey("dbo.Bets", "RecieptId", "dbo.Receipts");
            DropPrimaryKey("dbo.Receipts");
            AlterColumn("dbo.Receipts", "ReceiptId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Receipts", "Serial");
            AddPrimaryKey("dbo.Receipts", "ReceiptId");
            AddForeignKey("dbo.CancelReciepts", "RecieptId", "dbo.Receipts", "ReceiptId");
            AddForeignKey("dbo.Bets", "RecieptId", "dbo.Receipts", "ReceiptId", cascadeDelete: true);
            AddForeignKey("dbo.Receipts", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
