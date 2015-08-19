using Abp.Authorization;
using EOffice.MultiTenancy;
using EOffice.Users;

namespace EOffice.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}