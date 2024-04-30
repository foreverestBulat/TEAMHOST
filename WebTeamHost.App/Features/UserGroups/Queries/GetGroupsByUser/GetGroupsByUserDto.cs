using WebTeamHost.App.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Features.UserGroups.Queries.GetGroupsByUser
{
    public class GetGroupsByUserDto : IMapFrom<Group>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string UserId1 { get; init; }
    }
}
