namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WebProtal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IcmSubscriptions", "TenantId", "dbo.Tenants");
            DropIndex("dbo.IcmSubscriptions", new[] { "TenantId" });
            AlterColumn("dbo.IcmSubscriptions", "TenantId", c => c.Guid());
            CreateIndex("dbo.IcmSubscriptions", "TenantId");
            AddForeignKey("dbo.IcmSubscriptions", "TenantId", "dbo.Tenants", "TenantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IcmSubscriptions", "TenantId", "dbo.Tenants");
            DropIndex("dbo.IcmSubscriptions", new[] { "TenantId" });
            AlterColumn("dbo.IcmSubscriptions", "TenantId", c => c.Guid(nullable: false));
            CreateIndex("dbo.IcmSubscriptions", "TenantId");
            AddForeignKey("dbo.IcmSubscriptions", "TenantId", "dbo.Tenants", "TenantId", cascadeDelete: true);
        }
    }
}
