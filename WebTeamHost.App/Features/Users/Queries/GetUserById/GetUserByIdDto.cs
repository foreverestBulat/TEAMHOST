using Microsoft.AspNetCore.Identity;
using WebTeamHost.App.Common.Mappings;


namespace WebTeamHost.App.Features.Users.Queries.GetUserById
{
    public class GetUserByIdDto : IMapFrom<IdentityUser>
    {
        public string UserName { get; init; }
    }
}
