using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.UserGroups.Queries.GetUserGroupsByUser
{
    public class GetUserGroupsByUserDto : IMapFrom<Group>
    {
        public string UserId1 { get; init; }
        public int GroupId { get; init; }
    }
}
