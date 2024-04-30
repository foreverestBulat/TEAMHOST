using Microsoft.AspNetCore.Identity;
using WebTeamHost.Application.Common.Mappings;


namespace WebTeamHost.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdDto : IMapFrom<IdentityUser>
    {
        public string UserName { get; init; }
    }
}
