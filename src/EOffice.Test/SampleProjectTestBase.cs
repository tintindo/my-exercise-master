﻿using System;
using System.Data.Common;
using System.Linq;
using Abp.Collections;
using Abp.Modules;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using EOffice.EntityFramework;
using EOffice.Migrations.Data;

namespace EOffice.Test
{
    public abstract class SampleProjectTestBase : AbpIntegratedTestBase
    {
        protected SampleProjectTestBase()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            //Creating initial data
            UsingDbContext(context => new InitialDataBuilder().Build(context));
            
            AbpSession.TenantId = 1;
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);
            modules.Add<EOfficeApplicationModule>();
            modules.Add<EOfficeDataModule>();
        }

        public void UsingDbContext(Action<EOfficeDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<EOfficeDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<EOfficeDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<EOfficeDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
