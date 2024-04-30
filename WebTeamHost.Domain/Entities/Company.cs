using System.ComponentModel.DataAnnotations;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities;

/// <summary>
/// Разработчик
/// </summary>
public class Company : BaseAuditableEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    [Required]
    public string? Description { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    [Required]
    public Country? Country { get; set; }
    [Required]
    public int? CountryId { get; set; }
}