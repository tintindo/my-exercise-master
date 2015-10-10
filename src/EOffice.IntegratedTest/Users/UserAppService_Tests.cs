using System.Linq;
using Abp.Authorization;
using EOffice.Users;
using Shouldly;
using Xunit;

namespace EOffice.IntegratedTest.Users
{
    public class UserAppService_Tests : EOfficeIntegratedTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = LocalIocManager.Resolve<IUserAppService>();
        }

        [Fact]
        public void Should_Get_Users()
        {
            var output = _userAppService.GetUsers();
            output.Items.Count.ShouldBe(2); //Since initial data has 2 users.
            output.Items.FirstOrDefault(i => i.UserName == "admin").ShouldNotBe(null); //Since initial data has admin user
        }

        [Fact]
        public void Should_Get_Current_Users_With_Authorized_User()
        {
            AbpSession.UserId = 2;
            var output = _userAppService.GetCurrentUser();
            output.UserName.ShouldBe("admin");
        }

        [Fact]
        public void Should_Not_Get_Current_Users_Without_Authorized_User()
        {
            AbpSession.UserId = null; //not logged in
            Should.Throw<AbpAuthorizationException>(() => { _userAppService.GetCurrentUser(); });
        }
    }
}