using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities
{
    public class UserGroup : BaseAuditableEntity
    {
        public User User { get; set; }

        public string UserId { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
