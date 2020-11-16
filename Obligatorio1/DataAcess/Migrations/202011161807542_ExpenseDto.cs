namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseDto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseDtoes", "Description", c => c.String());
            AddColumn("dbo.ExpenseDtoes", "Amount", c => c.Double(nullable: false));
            AddColumn("dbo.ExpenseDtoes", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ExpenseDtoes", "Category_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.ExpenseDtoes", "Currency_Name", c => c.String(maxLength: 128));
            CreateIndex("dbo.ExpenseDtoes", "Category_Name");
            CreateIndex("dbo.ExpenseDtoes", "Currency_Name");
            AddForeignKey("dbo.ExpenseDtoes", "Category_Name", "dbo.CategoryDtoes", "Name");
            AddForeignKey("dbo.ExpenseDtoes", "Currency_Name", "dbo.CurrencyDtoes", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDtoes", "Currency_Name", "dbo.CurrencyDtoes");
            DropForeignKey("dbo.ExpenseDtoes", "Category_Name", "dbo.CategoryDtoes");
            DropIndex("dbo.ExpenseDtoes", new[] { "Currency_Name" });
            DropIndex("dbo.ExpenseDtoes", new[] { "Category_Name" });
            DropColumn("dbo.ExpenseDtoes", "Currency_Name");
            DropColumn("dbo.ExpenseDtoes", "Category_Name");
            DropColumn("dbo.ExpenseDtoes", "CreationDate");
            DropColumn("dbo.ExpenseDtoes", "Amount");
            DropColumn("dbo.ExpenseDtoes", "Description");
        }
    }
}
