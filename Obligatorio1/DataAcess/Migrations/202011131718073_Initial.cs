namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Symbol = c.String(),
                        Quotation = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Description = c.String(nullable: false, maxLength: 128),
                        Amount = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Category_Name = c.String(maxLength: 128),
                        Currency_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Description)
                .ForeignKey("dbo.Categories", t => t.Category_Name)
                .ForeignKey("dbo.Currencies", t => t.Currency_Name)
                .Index(t => t.Category_Name)
                .Index(t => t.Currency_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Currency_Name", "dbo.Currencies");
            DropForeignKey("dbo.Expenses", "Category_Name", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "Currency_Name" });
            DropIndex("dbo.Expenses", new[] { "Category_Name" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Currencies");
            DropTable("dbo.Categories");
        }
    }
}
