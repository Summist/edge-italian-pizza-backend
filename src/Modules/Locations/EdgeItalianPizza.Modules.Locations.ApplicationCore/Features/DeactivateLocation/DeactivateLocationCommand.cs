using EdgeItalianPizza.BuildingBlocks.CQRS;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Команда деактивации точки.
/// </summary>
public sealed record DeactivateLocationCommand(Guid LocationId) : ICommand<DeactivateLocationResult>;
