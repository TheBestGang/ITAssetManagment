namespace ITAssetManager.Domain.Licenses.ValueObjects;

public record LicenseReference
    {
    public string Value { get; }
    
    public LicenseReference(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Referensnummer får inte vara tomt.", nameof(value));
        }
        Value = value;
    }
    }

