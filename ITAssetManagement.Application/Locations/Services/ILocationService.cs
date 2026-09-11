namespace ITAssetManagement.Application.Locations.Services;

internal interface ILocationService
{
    CreateLocationResponse CreateCustomer(CreateCustomerRequest request);
    GetAllLocationsResponse GetAllLocations();
}
