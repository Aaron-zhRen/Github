namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "AppGroupId", "dbo.AppGroups");
            DropIndex("dbo.Admins", new[] { "AppGroupId" });
            RenameColumn(table: "dbo.Admins", name: "AppGroupId", newName: "AppGroup_AppGroupId");
            AlterColumn("dbo.Admins", "AppGroup_AppGroupId", c => c.Int());
            CreateIndex("dbo.Admins", "AppGroup_AppGroupId");
            AddForeignKey("dbo.Admins", "AppGroup_AppGroupId", "dbo.AppGroups", "AppGroupId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "AppGroup_AppGroupId", "dbo.AppGroups");
            DropIndex("dbo.Admins", new[] { "AppGroup_AppGroupId" });
            AlterColumn("dbo.Admins", "AppGroup_AppGroupId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Admins", name: "AppGroup_AppGroupId", newName: "AppGroupId");
            CreateIndex("dbo.Admins", "AppGroupId");
            AddForeignKey("dbo.Admins", "AppGroupId", "dbo.AppGroups", "AppGroupId", cascadeDelete: true);
        }
    }
}
