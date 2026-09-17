using ITAssetManagement.Application.Locations.Dtos;

namespace ITAssetManagement.Application.Locations.Services;

public interface ILocationService
{
    CreateLocationResponse CreateLocation(CreateLocationRequest request);
    GetLocationByLocationCodeResponse GetLocationByLocationCode(string locationCode);
    GetAllLocationsResponse GetAllLocations();
    UpdateLocationResponse UpdateLocation(UpdateLocationRequest request);
}
