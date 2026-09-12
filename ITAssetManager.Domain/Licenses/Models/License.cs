using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManager.Domain.Licenses.Models;

public class License(
    string licenseId,
    Name productName,
    LicenseReference licenseReference,
    SeatCount seatCount)
{
    public string LicenseId { get; } = licenseId;
    public Name ProductName { get; } = productName;
    public LicenseReference LicenseReference { get; } = licenseReference;
    public SeatCount SeatCount { get; set; } = seatCount;
}


