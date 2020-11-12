namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBudgetDto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetDtoes",
                c => new
                    {
                        BudgetDtoID = c.Int(nullable: false, identity: true),
                        TotalAmount = c.Double(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetDtoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BudgetDtoes");
        }
    }
}
