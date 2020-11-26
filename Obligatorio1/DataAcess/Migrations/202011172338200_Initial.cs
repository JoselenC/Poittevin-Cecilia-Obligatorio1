namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetDtoes",
                c => new
                    {
                        BudgetDtoID = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetDtoID);
            
            CreateTable(
                "dbo.BudgetCategoryDtoes",
                c => new
                    {
                        BudgetCategoryDtoID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Category_CategoryDtoID = c.Int(),
                        BudgetDto_BudgetDtoID = c.Int(),
                    })
                .PrimaryKey(t => t.BudgetCategoryDtoID)
                .ForeignKey("dbo.CategoryDtoes", t => t.Category_CategoryDtoID)
                .ForeignKey("dbo.BudgetDtoes", t => t.BudgetDto_BudgetDtoID)
                .Index(t => t.Category_CategoryDtoID)
                .Index(t => t.BudgetDto_BudgetDtoID);
            
            CreateTable(
                "dbo.CategoryDtoes",
                c => new
                    {
                        CategoryDtoID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.CategoryDtoID)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.KeyWordsDtoes",
                c => new
                    {
                        KeyWordsDtoID = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 450),
                        CategoryDto_CategoryDtoID = c.Int(),
                    })
                .PrimaryKey(t => t.KeyWordsDtoID)
                .ForeignKey("dbo.CategoryDtoes", t => t.CategoryDto_CategoryDtoID)
                .Index(t => t.Value, unique: true)
                .Index(t => t.CategoryDto_CategoryDtoID);
            
            CreateTable(
                "dbo.CurrencyDtoes",
                c => new
                    {
                        CurrencyDtoID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                        Symbol = c.String(),
                        Quotation = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyDtoID)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.ExpenseDtoes",
                c => new
                    {
                        ExpenseDtoID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Category_CategoryDtoID = c.Int(),
                        Currency_CurrencyDtoID = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenseDtoID)
                .ForeignKey("dbo.CategoryDtoes", t => t.Category_CategoryDtoID)
                .ForeignKey("dbo.CurrencyDtoes", t => t.Currency_CurrencyDtoID)
                .Index(t => t.Category_CategoryDtoID)
                .Index(t => t.Currency_CurrencyDtoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDtoes", "Currency_CurrencyDtoID", "dbo.CurrencyDtoes");
            DropForeignKey("dbo.ExpenseDtoes", "Category_CategoryDtoID", "dbo.CategoryDtoes");
            DropForeignKey("dbo.BudgetCategoryDtoes", "BudgetDto_BudgetDtoID", "dbo.BudgetDtoes");
            DropForeignKey("dbo.BudgetCategoryDtoes", "Category_CategoryDtoID", "dbo.CategoryDtoes");
            DropForeignKey("dbo.KeyWordsDtoes", "CategoryDto_CategoryDtoID", "dbo.CategoryDtoes");
            DropIndex("dbo.ExpenseDtoes", new[] { "Currency_CurrencyDtoID" });
            DropIndex("dbo.ExpenseDtoes", new[] { "Category_CategoryDtoID" });
            DropIndex("dbo.CurrencyDtoes", new[] { "Name" });
            DropIndex("dbo.KeyWordsDtoes", new[] { "CategoryDto_CategoryDtoID" });
            DropIndex("dbo.KeyWordsDtoes", new[] { "Value" });
            DropIndex("dbo.CategoryDtoes", new[] { "Name" });
            DropIndex("dbo.BudgetCategoryDtoes", new[] { "BudgetDto_BudgetDtoID" });
            DropIndex("dbo.BudgetCategoryDtoes", new[] { "Category_CategoryDtoID" });
            DropTable("dbo.ExpenseDtoes");
            DropTable("dbo.CurrencyDtoes");
            DropTable("dbo.KeyWordsDtoes");
            DropTable("dbo.CategoryDtoes");
            DropTable("dbo.BudgetCategoryDtoes");
            DropTable("dbo.BudgetDtoes");
        }
    }
}
