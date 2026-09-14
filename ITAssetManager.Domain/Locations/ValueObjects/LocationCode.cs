namespace ITAssetManager.Domain.Locations.ValueObjects;

public record LocationCode
{
    public string Value { get; }

    public LocationCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException("Du måste fylla i en platskod.", nameof(value));
        }

        string normalizedValue = value.Trim();

        Value = normalizedValue;
    }

    public override string ToString()
    {
        return Value;
    }
}

