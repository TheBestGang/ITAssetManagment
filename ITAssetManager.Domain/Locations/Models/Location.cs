using ITAssetManager.Domain.Locations.ValueObjects;

namespace ITAssetManager.Domain.Locations.Models;

public class Location(Guid locationId, LocationCode locationCode, LocationName locationName)
{
    public Guid LocationId { get; init; } = locationId;
    public LocationCode LocationCode { get; init; } = locationCode;
    public LocationName LocationName { get; private set; } = locationName;

    public void Rename(LocationName locationName)
    {
        LocationName = locationName;
    }
}
