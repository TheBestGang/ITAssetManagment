using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManager.Domain.Licenses.Models;

public class License
{
    public string LicenseId { get; } = null!;
    public Name ProductName { get; set; } = null!;
    public LicenseReference LicenseReference { get; set; } = null!;
    public SeatCount SeatCount { get; set; } = null!;
}


{

{
