namespace ITAssetManager.Domain.Licenses.Models;

public class License
{
    public Guid LicenseId { get;}
    public Name ProductName { get; set; } = null!;
    public LicenseReference LicenseReference { get; set; } = null!;
    public int SeatCount { get; set; }
}

public record Name
{
    public string Value { get; }
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(value));
        }
        Value = value;
    }
}
public record LicenseReference
    {
    public string Value { get; }
    
    public LicenseReference(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("License reference cannot be null or empty.", nameof(value));
        }
        Value = value;
    }
}
public record SeatCount
{
    public int Value { get; }
    
    public SeatCount(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Seat count cannot be negative.", nameof(value));
        }
        Value = value;
    }
}