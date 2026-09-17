using ITAssetManagement.Application.Locations.Dtos;
using ITAssetManager.Domain.Locations.Interfaces;
using ITAssetManager.Domain.Locations.Models;
using ITAssetManager.Domain.Locations.ValueObjects;


namespace ITAssetManagement.Application.Locations.Services;

public class LocationService(ILocationStore locationStore) : ILocationService
{
    public CreateLocationResponse CreateLocation(CreateLocationRequest request)
    {
        Location location;
        bool added;

        if (request is null)
        {
            return new CreateLocationResponse(false, null, "Platsen kan inte vara null.");
        }

        try
        {
            Guid? locationId = request.LocationId;
            LocationCode locationCode = new LocationCode(request.LocationCode);
            LocationName locationName = new LocationName(request.LocationName);

            location = Create(locationId, locationCode, locationName);
            added = locationStore.Add(location);
        }
        catch (Exception ex)
        {
            return new CreateLocationResponse(false, null, ex.Message);
        }

        return added
            ? new CreateLocationResponse(true, location, null)
            : new CreateLocationResponse(false, location, "Kunde inte spara platsen.");
    }

    private Location Create(Guid? locationId, LocationCode locationCode, LocationName locationName)
    {
        if (locationId is null)
        {
            locationId = GenerateNewId();
        }
        
        Location customer = new Location((Guid)locationId, locationCode, locationName);

        return customer;
    }

    public GetLocationByLocationCodeResponse GetLocationByLocationCode(string locationCode)
    {
        Location? location = locationStore.GetLocationByLocationCode(locationCode);

        if (location is null)
        {
            return new GetLocationByLocationCodeResponse(false, null, $"Kunde inte hitta en plats med platskoden '{locationCode}'");
        }
        else
        {
            return new GetLocationByLocationCodeResponse(true, location, null);
        }
    }

    private Guid GenerateNewId() => Guid.NewGuid();

    public GetAllLocationsResponse GetAllLocations()
    {
        IReadOnlyList<Location> locations = locationStore.GetAllLocations();

        return new GetAllLocationsResponse(true, locations, null);
    }

    public UpdateLocationResponse UpdateLocation(UpdateLocationRequest request)
    {
        if (request is null)
        {
            return new UpdateLocationResponse(false, null, "Platsen kan inte vara null.");
        }

        if (request.UpdatedLocation.LocationId == Guid.Empty)
        {
            return new UpdateLocationResponse(false, request.UpdatedLocation, "Platsen måste ha ett id.");
        }

        Location? location = locationStore.GetLocationByLocationCode(request.UpdatedLocation.LocationCode.Value);

        if (location is null)
        {
            return new UpdateLocationResponse(false, null, $"Platsen med id '{request.UpdatedLocation.LocationId}' kunde inte hittas.");
        }

        try
        {
             Location updated = locationStore.Update(request.UpdatedLocation);
        }
        catch (Exception ex)
        {
            return new UpdateLocationResponse(false, null, ex.Message);
        }

        return new UpdateLocationResponse(true, request.UpdatedLocation, null);
    }
}
