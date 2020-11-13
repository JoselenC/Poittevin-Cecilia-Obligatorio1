namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyDTO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrencyDtoes",
                c => new
                    {
                        CurrencyDtoID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Symbol = c.String(),
                        Quotation = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyDtoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CurrencyDtoes");
        }
    }
}
