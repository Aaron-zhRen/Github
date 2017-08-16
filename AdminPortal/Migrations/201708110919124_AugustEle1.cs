namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AugustEle1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Applications", "Tenant_TenantId", c => c.Guid());
            CreateIndex("dbo.Applications", "Tenant_TenantId");
            AddForeignKey("dbo.Applications", "Tenant_TenantId", "dbo.Tenants", "TenantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "Tenant_TenantId", "dbo.Tenants");
            DropIndex("dbo.Applications", new[] { "Tenant_TenantId" });
            DropColumn("dbo.Applications", "Tenant_TenantId");
            DropColumn("dbo.Applications", "TenantId");
        }
    }
}
