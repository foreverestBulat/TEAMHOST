using WebTeamHost.App.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Features.UserGroups.Queries.GetUserGroupsByUser
{
    public class GetUserGroupsByUserDto : IMapFrom<Group>
    {
        public string UserId1 { get; init; }
        public int GroupId { get; init; }
    }
}
