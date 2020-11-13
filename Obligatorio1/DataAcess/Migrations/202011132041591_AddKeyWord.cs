namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyWord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeyWords",
                c => new
                    {
                        keyWord = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.keyWord);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KeyWords");
        }
    }
}
