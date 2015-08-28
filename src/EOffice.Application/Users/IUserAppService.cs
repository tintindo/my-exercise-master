using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EOffice.Users.Dto;

namespace EOffice.Users
{
    public interface IUserAppService : IApplicationService
    {
        ListResultOutput<UserDto> GetUsers();
        UserDto GetCurrentUser();
    }
}
