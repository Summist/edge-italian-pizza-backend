using System.ComponentModel.DataAnnotations;

namespace EdgeItalianPizza.Modules.Locations.Persistence.MongoDb.Options;

/// <summary>
/// Настройки подключения к MongoDB.
/// </summary>
public sealed class MongoDbOptions
{
    /// <summary>
    /// Имя секции в appsettings.json.
    /// </summary>
    public const string SectionName = "MongoDbSettings";

    /// <summary>
    /// Строка подключения к MongoDB.
    /// </summary>
    [Required]
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// Имя базы данных.
    /// </summary>
    [Required]
    public string DatabaseName { get; set; } = string.Empty;
}
