 namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class ExposeFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BudgetCategoryDtoes", "BudgetDto_BudgetDtoID", "dbo.BudgetDtoes");
            DropForeignKey("dbo.KeyWordsDtoes", "CategoryDto_CategoryDtoID", "dbo.CategoryDtoes");
            DropIndex("dbo.BudgetCategoryDtoes", new[] { "BudgetDto_BudgetDtoID" });
            DropIndex("dbo.KeyWordsDtoes", new[] { "CategoryDto_CategoryDtoID" });
            RenameColumn(table: "dbo.BudgetCategoryDtoes", name: "BudgetDto_BudgetDtoID", newName: "BudgetDtoID");
            RenameColumn(table: "dbo.KeyWordsDtoes", name: "CategoryDto_CategoryDtoID", newName: "CategoryDtoID");
            AlterColumn("dbo.BudgetCategoryDtoes", "BudgetDtoID", c => c.Int(nullable: false));
            AlterColumn("dbo.KeyWordsDtoes", "CategoryDtoID", c => c.Int(nullable: false));
            CreateIndex("dbo.BudgetCategoryDtoes", "BudgetDtoID");
            CreateIndex("dbo.KeyWordsDtoes", "CategoryDtoID");
            AddForeignKey("dbo.BudgetCategoryDtoes", "BudgetDtoID", "dbo.BudgetDtoes", "BudgetDtoID", cascadeDelete: true);
            AddForeignKey("dbo.KeyWordsDtoes", "CategoryDtoID", "dbo.CategoryDtoes", "CategoryDtoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyWordsDtoes", "CategoryDtoID", "dbo.CategoryDtoes");
            DropForeignKey("dbo.BudgetCategoryDtoes", "BudgetDtoID", "dbo.BudgetDtoes");
            DropIndex("dbo.KeyWordsDtoes", new[] { "CategoryDtoID" });
            DropIndex("dbo.BudgetCategoryDtoes", new[] { "BudgetDtoID" });
            AlterColumn("dbo.KeyWordsDtoes", "CategoryDtoID", c => c.Int());
            AlterColumn("dbo.BudgetCategoryDtoes", "BudgetDtoID", c => c.Int());
            RenameColumn(table: "dbo.KeyWordsDtoes", name: "CategoryDtoID", newName: "CategoryDto_CategoryDtoID");
            RenameColumn(table: "dbo.BudgetCategoryDtoes", name: "BudgetDtoID", newName: "BudgetDto_BudgetDtoID");
            CreateIndex("dbo.KeyWordsDtoes", "CategoryDto_CategoryDtoID");
            CreateIndex("dbo.BudgetCategoryDtoes", "BudgetDto_BudgetDtoID");
            AddForeignKey("dbo.KeyWordsDtoes", "CategoryDto_CategoryDtoID", "dbo.CategoryDtoes", "CategoryDtoID");
            AddForeignKey("dbo.BudgetCategoryDtoes", "BudgetDto_BudgetDtoID", "dbo.BudgetDtoes", "BudgetDtoID");
        }
    }
}
