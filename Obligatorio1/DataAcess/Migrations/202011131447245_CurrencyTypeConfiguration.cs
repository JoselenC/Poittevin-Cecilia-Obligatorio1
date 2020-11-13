namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyTypeConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Symbol = c.String(),
                        Quotation = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            DropTable("dbo.CurrencyDtoes");
        }
        
        public override void Down()
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
            
            DropTable("dbo.Currencies");
        }
    }
}
