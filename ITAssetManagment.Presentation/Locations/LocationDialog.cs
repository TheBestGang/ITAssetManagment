using ITAssetManagement.Application.Locations.Services;
using ITAssetManager.Domain.Locations.Models;

namespace ITAssetManagment.Presentation.Locations;

internal class LocationDialog(ILocationService locationService)
{
    public void RunLocationDialog()
    {
        RunDialogLoop();
    }

    private void RunDialogLoop()
    {
        bool continueLocationLoop = true;

        do
        {
            PrintMenu();
            int choice = GetUserChoice();
            continueLocationLoop = HandleUserChoice(choice);
        }
        while (continueLocationLoop);
    }

    private void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Lägg till en plats");
        Console.WriteLine("2. Visa alla tillagda platser");
        Console.WriteLine("3. Ändra en plats");
        Console.WriteLine("0. Gå tillbaka till huvudmenyn");
        Console.WriteLine();
        Console.Write("Ange ditt val: ");
    }

    private int GetUserChoice()
    {
        string input = Console.ReadLine() ?? string.Empty;

        _ = int.TryParse(input, out int choice);

        return choice;
    }

    private bool HandleUserChoice(int choice)
    {
        bool continueLoop = true;

        switch (choice)
        {
            case 1:
                ShowCreateNewLocationDialog();
                break;

            case 2:
                ShowAllLocations();
                break;

            case 3:
                ShowUpdateLocationDialog();
                break;

            case 0:
                continueLoop = false;
                break;

            default:
                InvalidMenuChoiceMessage();
                break;
        }

        return continueLoop;
    }

    private void ShowCreateNewLocationDialog()
    {
        throw new NotImplementedException();
    }

    private void ShowAllLocations()
    {
        IReadOnlyList<Location> locations = locationService.GetAllLocations().Locations;

        if (locations.Count > 0)
        {
            foreach (Location location in locations)
            {
                Console.WriteLine($"Platskod: {location.LocationCode}");
                Console.WriteLine($"Platsnamn: {location.LocationName}");
                Console.WriteLine($"Id: {location.LocationId}");
            }
        }

    }

    private void ShowUpdateLocationDialog()
    {
        throw new NotImplementedException();
    }

    private void InvalidMenuChoiceMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Ogiltigt menyval, var god välj mellan alternativ 0-3.");
        Console.WriteLine();
        Console.WriteLine($"Klicka på någon tangent för att fortsätta.");
        Console.ReadKey();
    }
}
