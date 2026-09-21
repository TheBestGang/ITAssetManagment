namespace ITAssetManagement.Application.Locations.Dtos;

public record CreateLocationRequest
(
    Guid? LocationId,
    string LocationCode,
    string LocationName
);
