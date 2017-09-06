namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webpotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IcmRoutings", "IcmName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IcmRoutings", "IcmName");
        }
    }
}
