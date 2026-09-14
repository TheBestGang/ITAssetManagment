namespace ITAssetManager.Domain.Licenses.ValueObjects;

public record SeatCount
{
    public int Value { get; }
    
    public SeatCount(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Antalet kan inte vara negativt.", nameof(value));
        }
        Value = value;
    }
}
