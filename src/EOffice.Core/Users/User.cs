using Abp.Authorization.Users;
using EOffice.MultiTenancy;

namespace EOffice.Users
{
    public class User : AbpUser<Tenant, User>
    {
        public override string ToString()
        {
            return string.Format("[User {0}] {1}", Id, UserName);
        }
    }
}