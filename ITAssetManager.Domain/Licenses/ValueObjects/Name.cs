namespace ITAssetManager.Domain.Licenses.ValueObjects;

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
