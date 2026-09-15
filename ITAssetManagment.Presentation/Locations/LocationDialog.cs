using ITAssetManagement.Application.Locations.Dtos;
using ITAssetManagement.Application.Locations.Services;
using ITAssetManager.Domain.Locations.Models;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;

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
                InvalidInputMessage("Ogiltigt menyval, var god välj mellan alternativ 0-3");
                break;
        }

        return continueLoop;
    }

    private void ShowCreateNewLocationDialog()
    {
        string locationCode = InputDialog("Platskod");
        string locationName = InputDialog("Platsnamn");

        CreateLocationRequest request = new CreateLocationRequest(null, locationCode, locationName);
        CreateLocationResponse response = locationService.CreateLocation(request);

        Console.Clear();

        if (response.Succeeded)
        {
            if (response.Location is not null)
            {
                Console.WriteLine($"{response.Location.LocationName} har blivit tillagd!");
            }
            else
            {
                Console.WriteLine("Kunde inte lägga till plasten.");
            }
        }
        else
        {
            Console.WriteLine(response.ErrorMessage);
        }
    }

    private string InputDialog(string text)
    {
        string value = string.Empty;
        bool invalidInput = true;

        do
        {
            value = GetUserInput(text);
            
            if (string.IsNullOrWhiteSpace(value))
            {
                InvalidInputMessage($"{text} är obligatorisk");
            }
        }
        while (invalidInput);

        return value;
    }

    private string GetUserInput(string text)
    {
        string value = string.Empty;

        Console.Clear();
        Console.Write($"Ange {text.ToLower()}: ");
        
        value = Console.ReadLine() ?? string.Empty;

        return value;
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

    private void InvalidInputMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine($"{message}.");
        Console.WriteLine();
        Console.WriteLine($"Klicka på någon tangent för att fortsätta.");
        Console.ReadKey();
    }
}
