using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.UserGroups.Queries.GetGroupsByUser
{
    public class GetGroupsByUserDto : IMapFrom<Group>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string UserId1 { get; init; }
    }
}
