namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseDto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenseDtoes", "Category_CategoryDtoID", "dbo.CategoryDtoes");
            DropForeignKey("dbo.ExpenseDtoes", "Currency_CurrencyDtoID", "dbo.CurrencyDtoes");
            DropIndex("dbo.ExpenseDtoes", new[] { "Category_CategoryDtoID" });
            DropIndex("dbo.ExpenseDtoes", new[] { "Currency_CurrencyDtoID" });
            RenameColumn(table: "dbo.ExpenseDtoes", name: "Category_CategoryDtoID", newName: "CategoryDtoID");
            RenameColumn(table: "dbo.ExpenseDtoes", name: "Currency_CurrencyDtoID", newName: "CurrencyDtoID");
            AlterColumn("dbo.ExpenseDtoes", "CategoryDtoID", c => c.Int(nullable: false));
            AlterColumn("dbo.ExpenseDtoes", "CurrencyDtoID", c => c.Int(nullable: false));
            CreateIndex("dbo.ExpenseDtoes", "CategoryDtoID");
            CreateIndex("dbo.ExpenseDtoes", "CurrencyDtoID");
            AddForeignKey("dbo.ExpenseDtoes", "CategoryDtoID", "dbo.CategoryDtoes", "CategoryDtoID", cascadeDelete: true);
            AddForeignKey("dbo.ExpenseDtoes", "CurrencyDtoID", "dbo.CurrencyDtoes", "CurrencyDtoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDtoes", "CurrencyDtoID", "dbo.CurrencyDtoes");
            DropForeignKey("dbo.ExpenseDtoes", "CategoryDtoID", "dbo.CategoryDtoes");
            DropIndex("dbo.ExpenseDtoes", new[] { "CurrencyDtoID" });
            DropIndex("dbo.ExpenseDtoes", new[] { "CategoryDtoID" });
            AlterColumn("dbo.ExpenseDtoes", "CurrencyDtoID", c => c.Int());
            AlterColumn("dbo.ExpenseDtoes", "CategoryDtoID", c => c.Int());
            RenameColumn(table: "dbo.ExpenseDtoes", name: "CurrencyDtoID", newName: "Currency_CurrencyDtoID");
            RenameColumn(table: "dbo.ExpenseDtoes", name: "CategoryDtoID", newName: "Category_CategoryDtoID");
            CreateIndex("dbo.ExpenseDtoes", "Currency_CurrencyDtoID");
            CreateIndex("dbo.ExpenseDtoes", "Category_CategoryDtoID");
            AddForeignKey("dbo.ExpenseDtoes", "Currency_CurrencyDtoID", "dbo.CurrencyDtoes", "CurrencyDtoID");
            AddForeignKey("dbo.ExpenseDtoes", "Category_CategoryDtoID", "dbo.CategoryDtoes", "CategoryDtoID");
        }
    }
}
