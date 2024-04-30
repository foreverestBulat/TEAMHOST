using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.UsersInfo.Queries.GetUserInfoById
{
    public class GetUserInfoByUserDto : IMapFrom<UserInfo>
    {
        public int Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? About { get; init; }
        public DateOnly? BirthDay { get; init; }
        public string? UserId1 { get; init; }
        public int? CountryId { get; init; }
    }
}
