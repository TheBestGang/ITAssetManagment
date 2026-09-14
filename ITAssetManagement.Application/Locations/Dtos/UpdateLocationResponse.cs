using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManagement.Application.Locations.Dtos;

public record UpdateLocationResponse
(
    bool Succeeded,
    Location? Location,
    string? ErrorMessage
);
