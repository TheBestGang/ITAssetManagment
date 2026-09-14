using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManager.Domain.Locations.Interfaces;

public interface ILocationStore
{
    bool Add(Location location);
    IReadOnlyList<Location> GetAllLocations();
    Location? GetLocationById(Guid locationId);
    Location Update(Location updatedLocation);
}
