namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryDtoes",
                c => new
                    {
                        CategoryDtoID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryDtoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategoryDtoes");
        }
    }
}
