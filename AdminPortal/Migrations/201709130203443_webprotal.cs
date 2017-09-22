namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webprotal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "AppTypeId", "dbo.AppTypes");
            DropIndex("dbo.Applications", new[] { "AppTypeId" });
            RenameColumn(table: "dbo.AppGroups", name: "Name", newName: "AppGroup Name");
            RenameColumn(table: "dbo.AppGroups", name: "Description", newName: "AppGroup Description");
            RenameColumn(table: "dbo.Applications", name: "Name", newName: "Application Name");
            RenameColumn(table: "dbo.Applications", name: "Description", newName: "Application Description");
            RenameColumn(table: "dbo.Environments", name: "Name", newName: "Environment Name");
            RenameColumn(table: "dbo.Environments", name: "Description", newName: "Environment Description");
            RenameColumn(table: "dbo.Tenants", name: "Name", newName: "Tenant Name");
            RenameColumn(table: "dbo.Tenants", name: "Description", newName: "Tenant Description");
            AlterColumn("dbo.AppGroups", "AppGroup Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.AppGroups", "AppGroup Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Applications", "Application Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Applications", "Application Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Applications", "AlertEmails", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "Owners", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "AppTypeId", c => c.Int());
            AlterColumn("dbo.Applications", "TenantId", c => c.String(nullable: false));
            AlterColumn("dbo.Tenants", "Tenant Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Tenants", "Tenant Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Tenants", "Owners", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Applications", "AppTypeId");
            AddForeignKey("dbo.Applications", "AppTypeId", "dbo.AppTypes", "AppTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "AppTypeId", "dbo.AppTypes");
            DropIndex("dbo.Applications", new[] { "AppTypeId" });
            AlterColumn("dbo.Tenants", "Owners", c => c.String(maxLength: 10));
            AlterColumn("dbo.Tenants", "Tenant Description", c => c.String(maxLength: 20));
            AlterColumn("dbo.Tenants", "Tenant Name", c => c.String(maxLength: 10));
            AlterColumn("dbo.Applications", "TenantId", c => c.String());
            AlterColumn("dbo.Applications", "AppTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "Owners", c => c.String());
            AlterColumn("dbo.Applications", "AlertEmails", c => c.String());
            AlterColumn("dbo.Applications", "Application Description", c => c.String());
            AlterColumn("dbo.Applications", "Application Name", c => c.String());
            AlterColumn("dbo.AppGroups", "AppGroup Description", c => c.String());
            AlterColumn("dbo.AppGroups", "AppGroup Name", c => c.String());
            RenameColumn(table: "dbo.Tenants", name: "Tenant Description", newName: "Description");
            RenameColumn(table: "dbo.Tenants", name: "Tenant Name", newName: "Name");
            RenameColumn(table: "dbo.Environments", name: "Environment Description", newName: "Description");
            RenameColumn(table: "dbo.Environments", name: "Environment Name", newName: "Name");
            RenameColumn(table: "dbo.Applications", name: "Application Description", newName: "Description");
            RenameColumn(table: "dbo.Applications", name: "Application Name", newName: "Name");
            RenameColumn(table: "dbo.AppGroups", name: "AppGroup Description", newName: "Description");
            RenameColumn(table: "dbo.AppGroups", name: "AppGroup Name", newName: "Name");
            CreateIndex("dbo.Applications", "AppTypeId");
            AddForeignKey("dbo.Applications", "AppTypeId", "dbo.AppTypes", "AppTypeId", cascadeDelete: true);
        }
    }
}
