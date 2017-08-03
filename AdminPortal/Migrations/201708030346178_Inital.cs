namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "AppGroup_AppGroupId", "dbo.AppGroups");
            DropIndex("dbo.Admins", new[] { "AppGroup_AppGroupId" });
            RenameColumn(table: "dbo.Admins", name: "AppGroup_AppGroupId", newName: "AppGroupId");
            AlterColumn("dbo.Admins", "TenantName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "AppGroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.AppGroups", "AppGroupName", c => c.String(nullable: false));
            CreateIndex("dbo.Admins", "AppGroupId");
            AddForeignKey("dbo.Admins", "AppGroupId", "dbo.AppGroups", "AppGroupId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "AppGroupId", "dbo.AppGroups");
            DropIndex("dbo.Admins", new[] { "AppGroupId" });
            AlterColumn("dbo.AppGroups", "AppGroupName", c => c.String());
            AlterColumn("dbo.Admins", "AppGroupId", c => c.Int());
            AlterColumn("dbo.Admins", "TenantName", c => c.String());
            RenameColumn(table: "dbo.Admins", name: "AppGroupId", newName: "AppGroup_AppGroupId");
            CreateIndex("dbo.Admins", "AppGroup_AppGroupId");
            AddForeignKey("dbo.Admins", "AppGroup_AppGroupId", "dbo.AppGroups", "AppGroupId");
        }
    }
}
