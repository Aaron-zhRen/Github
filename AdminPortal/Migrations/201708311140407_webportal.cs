namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webportal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "TenantId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "TenantId", c => c.Int(nullable: false));
        }
    }
}
