namespace Test.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileLocationMaxLength256 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.dbImages", "FileLocation", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.dbImages", "FileLocation", c => c.String(maxLength: 32));
        }
    }
}
