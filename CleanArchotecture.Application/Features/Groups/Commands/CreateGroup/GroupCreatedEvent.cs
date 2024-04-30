using WebTeamHost.Domain.Common;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.Groups.Commands.CreateGroup
{
    public class GroupCreatedEvent : BaseEvent
    {
        public Group Group { get; }

        public GroupCreatedEvent(Group group)
        {
            Group = group;
        }
    }
}
