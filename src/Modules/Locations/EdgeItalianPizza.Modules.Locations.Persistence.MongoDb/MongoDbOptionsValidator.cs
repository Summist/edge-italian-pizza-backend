using EdgeItalianPizza.Modules.Locations.Persistence.MongoDb.Options;
using Microsoft.Extensions.Options;

namespace EdgeItalianPizza.Modules.Locations.Persistence.MongoDb;

/// <summary>
/// Валидатор настроек MongoDB.
/// </summary>
internal sealed class MongoDbOptionsValidator : IValidateOptions<MongoDbOptions>
{
    public ValidateOptionsResult Validate(string? name, MongoDbOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.ConnectionString))
        {
            failures.Add("ConnectionString is required");
        }

        if (string.IsNullOrWhiteSpace(options.DatabaseName))
        {
            failures.Add("DatabaseName is required");
        }

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
