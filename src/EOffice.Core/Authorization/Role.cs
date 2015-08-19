using Abp.Authorization.Roles;
using EOffice.MultiTenancy;
using EOffice.Users;

namespace EOffice.Authorization
{
    public class Role : AbpRole<Tenant, User>
    {
        public Role()
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
    }
}