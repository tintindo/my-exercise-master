﻿using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using EOffice.EntityFramework;

namespace EOffice
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(EOfficeCoreModule))]
    public class EOfficeDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<EOfficeDbContext>(null);
        }
    }
}
