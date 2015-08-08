using Abp.Web.Mvc.Views;

namespace EOffice.Web.Views
{
    public abstract class EOfficeWebViewPageBase : EOfficeWebViewPageBase<dynamic>
    {

    }

    public abstract class EOfficeWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected EOfficeWebViewPageBase()
        {
            LocalizationSourceName = EOfficeConsts.LocalizationSourceName;
        }
    }
}