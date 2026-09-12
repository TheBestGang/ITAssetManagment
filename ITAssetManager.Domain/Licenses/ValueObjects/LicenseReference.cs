namespace ITAssetManager.Domain.Licenses.ValueObjects;

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

