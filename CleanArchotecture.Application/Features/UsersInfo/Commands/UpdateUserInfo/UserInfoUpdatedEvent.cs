using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Domain.Common;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.UsersInfo.Commands.UpdateUserInfo
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
