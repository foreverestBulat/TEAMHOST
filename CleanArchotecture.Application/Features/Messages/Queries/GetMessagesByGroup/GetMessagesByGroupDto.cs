using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.Messages.Queries.GetMessagesByGroup
{
    public class GetMessagesByGroupDto : IMapFrom<Message>
    {
        public int Id { get; init; }
        public string UserId { get; init; }
        public string Text { get; init; }
    }
}
