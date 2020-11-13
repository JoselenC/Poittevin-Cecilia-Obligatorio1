namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBudget : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Year = c.Int(nullable: false, identity: true),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Year);
            
            CreateTable(
                "dbo.BudgetCategories",
                c => new
                    {
                        Amount = c.Double(nullable: false),
                        Category_Name = c.String(maxLength: 128),
                        Budget_Year = c.Int(),
                    })
                .PrimaryKey(t => t.Amount)
                .ForeignKey("dbo.Categories", t => t.Category_Name)
                .ForeignKey("dbo.Budgets", t => t.Budget_Year)
                .Index(t => t.Category_Name)
                .Index(t => t.Budget_Year);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BudgetCategories", "Budget_Year", "dbo.Budgets");
            DropForeignKey("dbo.BudgetCategories", "Category_Name", "dbo.Categories");
            DropIndex("dbo.BudgetCategories", new[] { "Budget_Year" });
            DropIndex("dbo.BudgetCategories", new[] { "Category_Name" });
            DropTable("dbo.BudgetCategories");
            DropTable("dbo.Budgets");
        }
    }
}
