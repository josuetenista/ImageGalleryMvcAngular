namespace Test.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_Abp_360 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpAuditLogs", "BrowserInfo", c => c.String(maxLength: 512));
            AlterColumn("dbo.AbpUserLoginAttempts", "BrowserInfo", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUserLoginAttempts", "BrowserInfo", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpAuditLogs", "BrowserInfo", c => c.String(maxLength: 256));
        }
    }
}
