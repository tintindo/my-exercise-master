using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using EOffice.Authorization;
using EOffice.Configuration;

namespace EOffice
{
    [DependsOn(typeof(EOfficeCoreModule), typeof(AbpAutoMapperModule))]
    public class EOfficeApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Authorization.Providers.Add<EOfficeAuthorizationProvider>();
            Configuration.Settings.Providers.Add<MySettingProvider>();
        }
    }
}
