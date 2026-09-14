using ITAssetManager.Domain.Locations.Interfaces;
using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManagment.Infrastructure.Locations.InMemory;

internal class InMemoryLocationStore : ILocationStore
{
    private readonly List<Location> _locations = [];

    public bool Add(Location location)
    {
        if (location is null)
        {
            return false;
        }

        _locations.Add(location);

        return true;
    }

    public IReadOnlyList<Location> GetAllLocations()
    {
        return _locations.OrderBy(location => location.LocationName).ToList();
    }

    public Location? GetLocationById(Guid locationId)
    {
        Location? location = _locations.FirstOrDefault(location => location.LocationId == locationId);

        return location;
    }

    public Location Update(Location updatedLocation)
    {
        if (updatedLocation is null) 
        {
            throw new ArgumentException("Location can't be null.");
        }

        int index = _locations.FindIndex(location => location.LocationId == updatedLocation.LocationId);

        if (index == -1)
        {
            throw new KeyNotFoundException($"Location with ID '{updatedLocation.LocationId}' was not found.");
        }

        _locations[index] = updatedLocation;

        return updatedLocation;
    }
}
