namespace DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditKeyWord : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.KeyWords");
            AddColumn("dbo.KeyWords", "Value", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.KeyWords", "Value");
            DropColumn("dbo.KeyWords", "keyWord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KeyWords", "keyWord", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.KeyWords");
            DropColumn("dbo.KeyWords", "Value");
            AddPrimaryKey("dbo.KeyWords", "keyWord");
        }
    }
}
