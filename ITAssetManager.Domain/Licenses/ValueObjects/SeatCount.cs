namespace ITAssetManager.Domain.Licenses.ValueObjects;

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
