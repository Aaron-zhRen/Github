namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webportal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tenants", "Name", c => c.String(maxLength: 10));
            AlterColumn("dbo.Tenants", "Description", c => c.String(maxLength: 20));
            AlterColumn("dbo.Tenants", "Owners", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenants", "Owners", c => c.String());
            AlterColumn("dbo.Tenants", "Description", c => c.String());
            AlterColumn("dbo.Tenants", "Name", c => c.String());
        }
    }
}
