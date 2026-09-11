using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManagement.Application.Locations.Dtos;

public record GetAllLocationsResponse
(
    bool Succeeded,
    IReadOnlyList<Location>? Locations,
    string? ErrorMessage
);
