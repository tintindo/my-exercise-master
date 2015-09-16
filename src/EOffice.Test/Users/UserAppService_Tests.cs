using System.Linq;
using Abp.TestBase.Runtime.Session;
using EOffice.Users;
using Shouldly;
using Xunit;

namespace EOffice.Test.Users
{
    public class UserAppService_Tests : SampleProjectTestBase
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
        public void Should_Get_Current_Users()
        {
            var abpSession = LocalIocManager.Resolve<TestAbpSession>();
            abpSession.UserId = 2;
            var output = _userAppService.GetCurrentUser();
            output.UserName.ShouldBe("admin"); 
        }
    }
}
