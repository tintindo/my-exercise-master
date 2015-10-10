using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using EOffice.Users.Dto;

namespace EOffice.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly UserManager _userManager;

        public UserAppService(UserManager userManager)
        {
            _userManager = userManager;
        }

        public ListResultOutput<UserDto> GetUsers()
        {
            return new ListResultOutput<UserDto>
                   {
                       Items = _userManager.Users.ToList().MapTo<List<UserDto>>()
                   };
        }

        [AbpAuthorize]
        public UserDto GetCurrentUser()
        {
            return _userManager.Users.First(t => t.Id == _userManager.AbpSession.UserId).MapTo<UserDto>();
        }
    }
}