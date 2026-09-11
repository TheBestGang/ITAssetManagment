using ITAssetManagement.Application.Locations.Dtos;

namespace ITAssetManagement.Application.Locations.Services;

internal interface ILocationService
{
    CreateLocationResponse CreateCustomer(CreateLocationRequest request);
    GetAllLocationsResponse GetAllLocations();
    UpdateLocationResponse UpdateLocation(UpdateLocationRequest request);
}
