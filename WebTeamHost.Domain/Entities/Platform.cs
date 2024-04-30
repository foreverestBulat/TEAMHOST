using System.ComponentModel.DataAnnotations;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities;

/// <summary>
/// Платформа
/// </summary>
public class Platform : BaseAuditableEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// Код
    /// </summary>
    [Required]
    public string? Code { get; set; }

    /// <summary>
    /// Изображение
    /// </summary>
    [Required]
    public StaticFile? Image { get; set; }
    [Required]
    public int? StaticFileId { get; set; }
}