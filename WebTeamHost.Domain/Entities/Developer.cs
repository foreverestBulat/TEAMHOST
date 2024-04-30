using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities
{
    public class Developer : BaseAuditableEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int? CountryId { get; set; }
        [Required]
        public Country? Country { get; set; }
        [Required]
        public virtual List<Game>? Games { get; set; }
    }
}
