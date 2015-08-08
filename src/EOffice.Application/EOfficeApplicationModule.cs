using System.Reflection;
using Abp.Modules;

namespace EOffice
{
    [DependsOn(typeof(EOfficeCoreModule))]
    public class EOfficeApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
