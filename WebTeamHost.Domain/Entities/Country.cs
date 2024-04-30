using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities
{
    public class Country : BaseAuditableEntity
    {
        /// <summary>
        /// короткое имя
        /// </summary>
        [Required]
        public string? Name { get; set; }

        /// <summary>
        /// числовой код страны
        /// </summary>
        [Required]
        public int Code { get; set; }

        /// <summary>
        /// полное название страны
        /// </summary>
        [Required]
        public string? FullName { get; set; }

        /// <summary>
        /// 2х-буквенный код
        /// </summary>
        [StringLength(2)]
        [Required]
        public string? Alpha2 { get; set; }

        /// <summary>
        /// 3х-буквенный код
        /// </summary>
        [StringLength(3)]
        [Required]
        public string? Alpha3 { get; set; }

        /// <summary>
        /// Список разработчиков
        /// </summary>
        [Required]
        public virtual List<Developer>? Developers { get; set; }
    }
}
