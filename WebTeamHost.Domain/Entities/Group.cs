using Microsoft.AspNetCore.Identity;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities
{
    public class Group : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
