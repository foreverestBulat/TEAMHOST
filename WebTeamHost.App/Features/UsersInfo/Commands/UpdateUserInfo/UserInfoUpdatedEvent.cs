using WebTeamHost.Domain.Common;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Features.UsersInfo.Commands.UpdateUserInfo
{
    public class UserInfoUpdatedEvent : BaseEvent
    {
        public UserInfo UserInfo { get; }

        public UserInfoUpdatedEvent(UserInfo userInfo)
        {
            UserInfo = userInfo;
        }
    }
}
