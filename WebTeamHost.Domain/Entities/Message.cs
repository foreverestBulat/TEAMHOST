using Microsoft.AspNetCore.Identity;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities
{
    public class Message : BaseAuditableEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Text { get; set; }
    }
}
