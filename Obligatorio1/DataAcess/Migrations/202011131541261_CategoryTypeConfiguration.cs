namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryTypeConfiguration : DbMigration
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
            
            DropTable("dbo.CategoryDtoes");
            DropTable("dbo.ExpenseDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExpenseDTOes",
                c => new
                    {
                        ExpenseDTOID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseDTOID);
            
            CreateTable(
                "dbo.CategoryDtoes",
                c => new
                    {
                        CategoryDtoID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryDtoID);
            
            DropForeignKey("dbo.Expenses", "Currency_Name", "dbo.Currencies");
            DropForeignKey("dbo.Expenses", "Category_Name", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "Currency_Name" });
            DropIndex("dbo.Expenses", new[] { "Category_Name" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Categories");
        }
    }
}
