using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManagement.Application.Locations.Dtos;

public record CreateLocationResponse
(
    bool Succeeded,
    Location Location,
    string? ErrorMessage
);
