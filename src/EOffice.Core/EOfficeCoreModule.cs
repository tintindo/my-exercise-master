using System.Reflection;
using Abp.Modules;

namespace EOffice
{
    public class EOfficeCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
