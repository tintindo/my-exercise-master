using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace EOffice
{
    [DependsOn(typeof(AbpWebApiModule), typeof(EOfficeApplicationModule))]
    public class EOfficeWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(EOfficeApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
