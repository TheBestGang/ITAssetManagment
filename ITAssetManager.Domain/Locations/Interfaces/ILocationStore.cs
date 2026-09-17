using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManager.Domain.Locations.Interfaces;

public interface ILocationStore
{
    bool Add(Location location);
    IReadOnlyList<Location> GetAllLocations();
    Location? GetLocationByLocationCode(string locationCode);
    Location Update(Location updatedLocation);
}
