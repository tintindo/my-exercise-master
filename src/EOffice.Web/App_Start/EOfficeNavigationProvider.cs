using Abp.Application.Navigation;
using Abp.Localization;

namespace EOffice.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class EOfficeNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", EOfficeConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Questions",
                        new LocalizableString("Questions", EOfficeConsts.LocalizationSourceName),
                        url: "#/questions",
                        icon: "fa fa-question"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        new LocalizableString("Users", EOfficeConsts.LocalizationSourceName),
                        url: "#/users",
                        icon: "fa fa-users"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", EOfficeConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                );
        }
    }
}
