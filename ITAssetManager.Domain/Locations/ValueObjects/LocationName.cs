namespace ITAssetManager.Domain.Locations.ValueObjects;

public record LocationName
{
    public string Value { get; }

    public LocationName(string value, int minLength = 2)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException("Du måste fylla i ett platsnamn.");
        }

        string normalizedValue = value.Trim();

        if (normalizedValue.Length < minLength)
        {
            throw new ArgumentException($"Platsnamn måste bestå av minst {minLength} bokstäver.");
        }

        Value = normalizedValue;
    }

    public override string ToString()
    {
        return Value;
    }
}