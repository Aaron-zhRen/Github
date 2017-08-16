namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AugustEle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        AppId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AlertEmails = c.String(),
                        CatchupModeWindow = c.Int(),
                        IsEnabled = c.Boolean(nullable: false),
                        IsIcmEnabled = c.Boolean(nullable: false),
                        AppTypeId = c.Int(nullable: false),
                        AppGroupId = c.Int(nullable: false),
                        IcmRoutingId = c.Int(),
                        ScheduleId = c.String(),
                        DateParameterName = c.String(),
                        DatePattern = c.String(),
                        RecurrenceId = c.Int(),
                        WorkflowRecurrence_RecurrenceId = c.Int(),
                        WorkflowRecurrence_Frequency = c.Int(),
                        WorkflowRecurrence_Internval = c.Int(),
                        WorkflowRecurrence_Minutes = c.String(),
                        WorkflowRecurrence_Hours = c.String(),
                        WorkflowRecurrence_RelativeInterval = c.Int(),
                        WorkflowRecurrence_DayOfWeek = c.Int(),
                        WorkflowRecurrence_DayOfMonth = c.Int(),
                    })
                .PrimaryKey(t => t.AppId)
                .ForeignKey("dbo.AppGroups", t => t.AppGroupId, cascadeDelete: true)
                .ForeignKey("dbo.IcmRoutings", t => t.IcmRoutingId)
                .ForeignKey("dbo.AppTypes", t => t.AppTypeId, cascadeDelete: true)
                .Index(t => t.AppTypeId)
                .Index(t => t.AppGroupId)
                .Index(t => t.IcmRoutingId);
            
            CreateTable(
                "dbo.AppGroups",
                c => new
                    {
                        AppGroupId = c.Int(nullable: false, identity: true),
                        TenantId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AppGroupId)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        TenantId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Owners = c.String(),
                    })
                .PrimaryKey(t => t.TenantId);
            
            CreateTable(
                "dbo.IcmSubscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Guid(nullable: false),
                        ServiceName = c.String(),
                        ConnectorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.IcmRoutings",
                c => new
                    {
                        IcmRoutingId = c.Int(nullable: false, identity: true),
                        IcmSubscriptionId = c.Int(nullable: false),
                        RoutingId = c.String(),
                        CorrelationId = c.String(),
                    })
                .PrimaryKey(t => t.IcmRoutingId)
                .ForeignKey("dbo.IcmSubscriptions", t => t.IcmSubscriptionId, cascadeDelete: true)
                .Index(t => t.IcmSubscriptionId);
            
            CreateTable(
                "dbo.AppTypes",
                c => new
                    {
                        AppTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AppTypeId);
            
            CreateTable(
                "dbo.CounterInstances",
                c => new
                    {
                        CounterInstanceId = c.Long(nullable: false, identity: true),
                        AppId = c.Int(nullable: false),
                        CounterId = c.Int(nullable: false),
                        EnvId = c.Int(nullable: false),
                        Delta = c.DateTime(nullable: false),
                        AppInstanceId = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        CounterValue = c.Long(nullable: false),
                        Machine = c.String(),
                        ServiceInstance = c.String(),
                        Annotation = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CounterInstanceId)
                .ForeignKey("dbo.Applications", t => t.AppId, cascadeDelete: true)
                .ForeignKey("dbo.Counters", t => t.CounterId, cascadeDelete: true)
                .ForeignKey("dbo.Environments", t => t.EnvId, cascadeDelete: true)
                .Index(t => t.AppId)
                .Index(t => t.CounterId)
                .Index(t => t.EnvId);
            
            CreateTable(
                "dbo.Alerts",
                c => new
                    {
                        AlertId = c.Long(nullable: false, identity: true),
                        CounterInstanceId = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        AlertEmails = c.String(),
                        IsDispatched = c.Boolean(nullable: false),
                        Subject = c.String(),
                        EmailBody = c.String(),
                        IcmBody = c.String(),
                        ServiceInstance = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.AlertId)
                .ForeignKey("dbo.CounterInstances", t => t.CounterInstanceId, cascadeDelete: true)
                .Index(t => t.CounterInstanceId);
            
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        IncidentId = c.Long(nullable: false, identity: true),
                        AlertId = c.Long(nullable: false),
                        FaultAppId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ServiceInstance = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        EmailSubject = c.String(),
                        Comment = c.String(),
                        IsDRIRequired = c.Boolean(nullable: false),
                        IsEmailRequired = c.Boolean(nullable: false),
                        IcmIncidentId = c.Long(),
                        IcmDescription = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        Application_AppId = c.Int(),
                    })
                .PrimaryKey(t => t.IncidentId)
                .ForeignKey("dbo.Alerts", t => t.AlertId, cascadeDelete: true)
                .ForeignKey("dbo.Applications", t => t.Application_AppId)
                .Index(t => t.AlertId)
                .Index(t => t.Application_AppId);
            
            CreateTable(
                "dbo.Counters",
                c => new
                    {
                        CounterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        IsIncremental = c.Boolean(nullable: false),
                        ThresholdUnit = c.String(),
                    })
                .PrimaryKey(t => t.CounterId);
            
            CreateTable(
                "dbo.Thresholds",
                c => new
                    {
                        ThresholdId = c.Int(nullable: false, identity: true),
                        AppId = c.Int(nullable: false),
                        CounterId = c.Int(nullable: false),
                        EnvId = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        IsIcmEnabled = c.Boolean(nullable: false),
                        Value = c.Long(nullable: false),
                        Operation = c.String(),
                        Severity = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThresholdId)
                .ForeignKey("dbo.Applications", t => t.AppId, cascadeDelete: true)
                .ForeignKey("dbo.Counters", t => t.CounterId, cascadeDelete: true)
                .ForeignKey("dbo.Environments", t => t.EnvId, cascadeDelete: true)
                .Index(t => t.AppId)
                .Index(t => t.CounterId)
                .Index(t => t.EnvId);
            
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        EnvId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnvId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thresholds", "EnvId", "dbo.Environments");
            DropForeignKey("dbo.CounterInstances", "EnvId", "dbo.Environments");
            DropForeignKey("dbo.Thresholds", "CounterId", "dbo.Counters");
            DropForeignKey("dbo.Thresholds", "AppId", "dbo.Applications");
            DropForeignKey("dbo.CounterInstances", "CounterId", "dbo.Counters");
            DropForeignKey("dbo.CounterInstances", "AppId", "dbo.Applications");
            DropForeignKey("dbo.Incidents", "Application_AppId", "dbo.Applications");
            DropForeignKey("dbo.Incidents", "AlertId", "dbo.Alerts");
            DropForeignKey("dbo.Alerts", "CounterInstanceId", "dbo.CounterInstances");
            DropForeignKey("dbo.Applications", "AppTypeId", "dbo.AppTypes");
            DropForeignKey("dbo.IcmSubscriptions", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.IcmRoutings", "IcmSubscriptionId", "dbo.IcmSubscriptions");
            DropForeignKey("dbo.Applications", "IcmRoutingId", "dbo.IcmRoutings");
            DropForeignKey("dbo.AppGroups", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.Applications", "AppGroupId", "dbo.AppGroups");
            DropIndex("dbo.Thresholds", new[] { "EnvId" });
            DropIndex("dbo.Thresholds", new[] { "CounterId" });
            DropIndex("dbo.Thresholds", new[] { "AppId" });
            DropIndex("dbo.Incidents", new[] { "Application_AppId" });
            DropIndex("dbo.Incidents", new[] { "AlertId" });
            DropIndex("dbo.Alerts", new[] { "CounterInstanceId" });
            DropIndex("dbo.CounterInstances", new[] { "EnvId" });
            DropIndex("dbo.CounterInstances", new[] { "CounterId" });
            DropIndex("dbo.CounterInstances", new[] { "AppId" });
            DropIndex("dbo.IcmRoutings", new[] { "IcmSubscriptionId" });
            DropIndex("dbo.IcmSubscriptions", new[] { "TenantId" });
            DropIndex("dbo.AppGroups", new[] { "TenantId" });
            DropIndex("dbo.Applications", new[] { "IcmRoutingId" });
            DropIndex("dbo.Applications", new[] { "AppGroupId" });
            DropIndex("dbo.Applications", new[] { "AppTypeId" });
            DropTable("dbo.Environments");
            DropTable("dbo.Thresholds");
            DropTable("dbo.Counters");
            DropTable("dbo.Incidents");
            DropTable("dbo.Alerts");
            DropTable("dbo.CounterInstances");
            DropTable("dbo.AppTypes");
            DropTable("dbo.IcmRoutings");
            DropTable("dbo.IcmSubscriptions");
            DropTable("dbo.Tenants");
            DropTable("dbo.AppGroups");
            DropTable("dbo.Applications");
        }
    }
}
