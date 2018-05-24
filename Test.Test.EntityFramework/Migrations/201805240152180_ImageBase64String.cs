namespace Test.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageBase64String : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dbImages", "ImageString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.dbImages", "ImageString");
        }
    }
}
