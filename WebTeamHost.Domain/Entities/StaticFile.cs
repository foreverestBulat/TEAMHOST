using System.ComponentModel.DataAnnotations;
using WebTeamHost.Domain.Common;

namespace WebTeamHost.Domain.Entities;

/// <summary>
/// Файл
/// </summary>
public class StaticFile : BaseAuditableEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="path">Путь</param>
    /// <param name="name">Имя</param>
    public StaticFile(string path, string name)
    {
        Path = path;
        Name = name;
        Extension = name.Split('.').LastOrDefault();
    }

    private StaticFile()
    {
    }

    /// <summary>
    /// Путь
    /// </summary>
    [Required]
    public string? Path { get; set; }

    /// <summary>
    /// Размер в КБ
    /// </summary>
    [Required]
    public int? Size { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// Расширение
    /// </summary>
    [Required]
    public string? Extension { get; private set; }
}