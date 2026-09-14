using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManagement.Application.Locations.Dtos;

public record UpdateLocationRequest
(
    Location UpdatedLocation
);