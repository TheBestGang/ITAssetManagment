namespace ITAssetManager.Domain.Locations.Models;

internal class Location(Guid locationId, string locationCode, string locationName)
{
    public Guid LocationId { get; set; } = locationId;
    public string LocationCode { get; init; } = locationCode;
    public string LocationName { get; set; } = locationName;

    public void ChangeLocationName(string locationName)
    {
        LocationName = locationName;
    }
}


