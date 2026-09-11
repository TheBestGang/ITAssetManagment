using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManager.Domain.Licenses.Models;

public class License
{
    public Guid LicenseId { get;}
    public Name ProductName { get; set; } = null!;
    public LicenseReference LicenseReference { get; set; } = null!;
    public SeatCount SeatCount { get; set; } = null!;
}


{

{
