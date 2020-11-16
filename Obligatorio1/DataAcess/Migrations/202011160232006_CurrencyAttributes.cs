namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrencyDtoes", "Symbol", c => c.String());
            AddColumn("dbo.CurrencyDtoes", "Quotation", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CurrencyDtoes", "Quotation");
            DropColumn("dbo.CurrencyDtoes", "Symbol");
        }
    }
}
