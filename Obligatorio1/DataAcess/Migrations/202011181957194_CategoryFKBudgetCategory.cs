namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class CategoryFKBudgetCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BudgetCategoryDtoes", "Category_CategoryDtoID", "dbo.CategoryDtoes");
            DropIndex("dbo.BudgetCategoryDtoes", new[] { "Category_CategoryDtoID" });
            RenameColumn(table: "dbo.BudgetCategoryDtoes", name: "Category_CategoryDtoID", newName: "CategoryDtoID");
            AlterColumn("dbo.BudgetCategoryDtoes", "CategoryDtoID", c => c.Int(nullable: false));
            CreateIndex("dbo.BudgetCategoryDtoes", "CategoryDtoID");
            AddForeignKey("dbo.BudgetCategoryDtoes", "CategoryDtoID", "dbo.CategoryDtoes", "CategoryDtoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BudgetCategoryDtoes", "CategoryDtoID", "dbo.CategoryDtoes");
            DropIndex("dbo.BudgetCategoryDtoes", new[] { "CategoryDtoID" });
            AlterColumn("dbo.BudgetCategoryDtoes", "CategoryDtoID", c => c.Int());
            RenameColumn(table: "dbo.BudgetCategoryDtoes", name: "CategoryDtoID", newName: "Category_CategoryDtoID");
            CreateIndex("dbo.BudgetCategoryDtoes", "Category_CategoryDtoID");
            AddForeignKey("dbo.BudgetCategoryDtoes", "Category_CategoryDtoID", "dbo.CategoryDtoes", "CategoryDtoID");
        }
    }
}
