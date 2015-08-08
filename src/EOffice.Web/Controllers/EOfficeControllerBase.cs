using Abp.Web.Mvc.Controllers;

namespace EOffice.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class EOfficeControllerBase : AbpController
    {
        protected EOfficeControllerBase()
        {
            LocalizationSourceName = EOfficeConsts.LocalizationSourceName;
        }
    }
}