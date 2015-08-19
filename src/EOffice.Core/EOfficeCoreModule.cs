using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace EOffice
{
	[DependsOn(typeof(AbpZeroCoreModule))]
    public class EOfficeCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
