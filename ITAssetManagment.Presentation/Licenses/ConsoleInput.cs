namespace ITAssetManagment.Presentation.Licenses;

internal static class ConsoleInput
{
    public static string ReadRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Trim();
            }

            Console.WriteLine("A value is required.");
        }
    }

    public static int ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out var value) && value >= 0)
            {
                return value;
            }

            Console.WriteLine("Enter a non-negative whole number.");
        }
    }
}
