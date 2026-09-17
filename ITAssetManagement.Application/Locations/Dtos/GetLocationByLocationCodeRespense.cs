using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManagement.Application.Locations.Dtos;

public record GetLocationByLocationCodeResponse
(
    bool Succeeded,
    Location? Location,
    string? ErrorMessage
);
