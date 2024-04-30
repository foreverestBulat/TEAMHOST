using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities
{
    public class Game : BaseAuditableEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public float? Price { get; set; }
        [Required]
        public string? Images { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public float? Rating { get; set; }
        [Required]
        public DateTime? DateReleased { get; set; }
        [Required]
        public string? MainImage { get; set; }

        /// <summary>
        /// Json
        /// </summary>
        [Required]
        public string? Platforms { get; set; }
        [Required]
        public int? DeveloperId { get; set; }
        [Required]
        public Developer? Developer { get; set; }
        [Required]
        public List<Category>? Categories { get; set; }



    }
}
