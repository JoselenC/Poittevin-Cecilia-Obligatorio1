namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseDTO : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExpenseDTOes");
        }
    }
}
