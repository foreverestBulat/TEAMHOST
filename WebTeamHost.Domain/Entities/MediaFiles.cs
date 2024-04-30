using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities
{
    public class MediaFiles : BaseAuditableEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Path { get; set; }
        [Required]
        public ulong? Size { get; set; }
    }
}
