using ITAssetManager.Domain.Locations.Interfaces;
using ITAssetManager.Domain.Locations.Models;
using ITAssetManager.Domain.Locations.ValueObjects;

namespace ITAssetManagment.Infrastructure.Locations.InMemory;

public class InMemoryLocationStore : ILocationStore
{
    private readonly List<Location> _locations = [];

    public bool Add(Location location)
    {
        if (location is null)
        {
            return false;
        }

        if (CheckIfLocationCodeDoesNotExist(location))
        {
            _locations.Add(location);
            return true;
        }
        else
        {
            throw new ArgumentException($"Det finns redan en plats med platskoden '{location.LocationCode}'.");
        }
    }

    private bool CheckIfLocationCodeDoesNotExist(Location location)
    {
        bool doesNotExist;
        Location? existingLocation = _locations.FirstOrDefault(l => l.LocationCode.Equals(location.LocationCode));

        if (existingLocation is null)
        {
            doesNotExist = true;
        }
        else
        {
            doesNotExist = false;
        }

        return doesNotExist;
    }

    public IReadOnlyList<Location> GetAllLocations()
    {
        return _locations.OrderBy(location => location.LocationName.Value).ToList();
    }

    public Location? GetLocationByLocationCode(string locationCode)
    {
        Location? location = _locations.FirstOrDefault(location => location.LocationCode.Value.Equals(locationCode));

        return location;
    }

    public Location Update(Location updatedLocation)
    {
        if (updatedLocation is null)
        {
            throw new ArgumentException("Platsen kan inte vara null.");
        }

        int index = _locations.FindIndex(location => location.LocationId == updatedLocation.LocationId);

        if (index == -1)
        {
            throw new KeyNotFoundException($"Platsen med ID '{updatedLocation.LocationId}' kunde inte hittas.");
        }

        _locations[index] = updatedLocation;

        return updatedLocation;
    }
}
