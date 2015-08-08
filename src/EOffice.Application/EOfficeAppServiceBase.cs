using Abp.Application.Services;

namespace EOffice
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class EOfficeAppServiceBase : ApplicationService
    {
        protected EOfficeAppServiceBase()
        {
            LocalizationSourceName = EOfficeConsts.LocalizationSourceName;
        }
    }
}