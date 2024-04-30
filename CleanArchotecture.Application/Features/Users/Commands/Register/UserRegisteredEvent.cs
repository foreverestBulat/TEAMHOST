using Microsoft.AspNetCore.Identity;
using WebTeamHost.Domain.Common;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.Users.Commands.Register
{
    internal class UserRegisteredEvent
    {
        public IdentityUser User { get; }

        public UserRegisteredEvent(IdentityUser user)
        {
            User = user;
        }
    }
}
