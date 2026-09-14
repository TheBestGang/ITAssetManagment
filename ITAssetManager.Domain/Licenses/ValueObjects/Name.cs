namespace ITAssetManager.Domain.Licenses.ValueObjects;

public record Name
{
    public string Value { get; }
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Du måste ange ett namn.", nameof(value));
        }
        Value = value;
    }
}
