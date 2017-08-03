namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AdminPortal.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AdminPortal.Models.OnboardServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AdminPortal.Models.OnboardServiceContext context)
        {
            context.AppGroups.AddOrUpdate(x => x.AppGroupId,
                new AppGroup() { AppGroupId = 1, AppGroupName  = "AGN1" ,AppGroupDescription ="AGND1"},
                new AppGroup() { AppGroupId = 2, AppGroupName = "AGN2" , AppGroupDescription = "AGND2" },
                new AppGroup() { AppGroupId = 3, AppGroupName = "AGN3" , AppGroupDescription = "AGND3" }
                );

            context.Admins.AddOrUpdate(x => x.AdminId,
                new Admin()
                {
                    AdminId = 1,
                    TenantName = "Admin-1",
                    IcmName = "ICMN1",
                    //AppGroupId = 1
                },
                new Admin()
                {
                    AdminId = 2,
                    TenantName = "Admin-2",
                    IcmName = "ICMN2",
                    //AppGroupId = 2
                },
                new Admin()
                {
                    AdminId = 3,
                    TenantName = "Admin-3",
                    IcmName = "ICMN3",
                    //AppGroupId = 1
                }
                );
        }
    }
}
