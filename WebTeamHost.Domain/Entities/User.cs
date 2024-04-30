using Microsoft.AspNetCore.Identity;
using WebTeamHost.Domain.Common;


namespace WebTeamHost.Domain.Entities
{
    public class User : IdentityUser
    {
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
