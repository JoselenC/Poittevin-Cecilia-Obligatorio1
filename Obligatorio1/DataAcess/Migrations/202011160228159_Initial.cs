namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
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
                        Category_Name = c.String(maxLength: 128),
                        BudgetDto_BudgetDtoID = c.Int(),
                    })
                .PrimaryKey(t => t.BudgetCategoryDtoID)
                .ForeignKey("dbo.CategoryDtoes", t => t.Category_Name)
                .ForeignKey("dbo.BudgetDtoes", t => t.BudgetDto_BudgetDtoID)
                .Index(t => t.Category_Name)
                .Index(t => t.BudgetDto_BudgetDtoID);
            
            CreateTable(
                "dbo.CategoryDtoes",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.KeyWordsDtoes",
                c => new
                    {
                        Value = c.String(nullable: false, maxLength: 128),
                        CategoryDto_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Value)
                .ForeignKey("dbo.CategoryDtoes", t => t.CategoryDto_Name)
                .Index(t => t.CategoryDto_Name);
            
            CreateTable(
                "dbo.CurrencyDtoes",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.ExpenseDtoes",
                c => new
                    {
                        ExpenseDtoID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ExpenseDtoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BudgetCategoryDtoes", "BudgetDto_BudgetDtoID", "dbo.BudgetDtoes");
            DropForeignKey("dbo.BudgetCategoryDtoes", "Category_Name", "dbo.CategoryDtoes");
            DropForeignKey("dbo.KeyWordsDtoes", "CategoryDto_Name", "dbo.CategoryDtoes");
            DropIndex("dbo.KeyWordsDtoes", new[] { "CategoryDto_Name" });
            DropIndex("dbo.BudgetCategoryDtoes", new[] { "BudgetDto_BudgetDtoID" });
            DropIndex("dbo.BudgetCategoryDtoes", new[] { "Category_Name" });
            DropTable("dbo.ExpenseDtoes");
            DropTable("dbo.CurrencyDtoes");
            DropTable("dbo.KeyWordsDtoes");
            DropTable("dbo.CategoryDtoes");
            DropTable("dbo.BudgetCategoryDtoes");
            DropTable("dbo.BudgetDtoes");
        }
    }
}
