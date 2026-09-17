using ITAssetManagement.Application.Locations.Dtos;
using ITAssetManagement.Application.Locations.Services;
using ITAssetManager.Domain.Locations.Models;
using ITAssetManager.Domain.Locations.ValueObjects;

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

        bool validNumber = int.TryParse(input, out int choice);

        if (!validNumber)
        {
            choice = -1;
        }

        return choice;
    }

    private bool HandleUserChoice(int choice)
    {
        bool continueLoop = true;

        Console.Clear();

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
                ShowMessage("Ogiltigt menyval, var god välj mellan alternativ 0-3.");
                break;
        }

        return continueLoop;
    }

    private void ShowCreateNewLocationDialog()
    {
        string locationCode = InputDialog("Platskod");
        string locationName = InputDialog("Platsnamn");

        CreateLocationResponse response = GetCreateLocationResponse(null, locationCode, locationName);

        Console.Clear();

        if (response.Succeeded)
        {
            if (response.Location is not null)
            {
                ShowMessage($"{response.Location.LocationName} har blivit tillagd!");
            }
            else
            {
                ShowMessage("Kunde inte lägga till plasten.");
            }
        }
        else
        {
            ShowMessage(response.ErrorMessage!);
        }
    }

    private CreateLocationResponse GetCreateLocationResponse(Guid? locationId, string locationCode, string locationName)
    {
        CreateLocationRequest request = new CreateLocationRequest(locationId, locationCode, locationName);
        CreateLocationResponse response = locationService.CreateLocation(request);
        return response;
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
                Console.Clear();
                ShowMessage($"{text} är obligatorisk.");
            }
            else
            {
                invalidInput = false;
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
            Console.WriteLine("--------- SPARADE PLATSER ---------");
            Console.WriteLine();

            foreach (Location location in locations)
            {
                Console.WriteLine($"Platskod: {location.LocationCode}");
                Console.WriteLine($"Platsnamn: {location.LocationName}");
                Console.WriteLine($"Id: {location.LocationId}");
                Console.WriteLine();
            }
        }
        else
        {
            ShowMessage("Det finns inga sparade platser.");
        }

        ShowMessage(string.Empty);
    }

    private void ShowUpdateLocationDialog()
    {
        if (locationService.GetAllLocations().Locations.Count == 0)
        {
            ShowMessage("Det finns inga sparade platser att ändra namn på.");
            return;
        }

        GetLocationByLocationCodeResponse getLocationResponse = GetLocationResponse();
        Console.Clear();

        if (getLocationResponse.Succeeded)
        {
            if (getLocationResponse.Location is not null)
            {
                UpdateLocationResponse updateResponse = UpdateLocation(getLocationResponse.Location);
                Console.Clear();

                if (updateResponse.Succeeded)
                {
                    ShowMessage($"Platsen med platskoden '{getLocationResponse.Location.LocationCode}' har blivit uppdaterad!");
                }
                else
                {
                    ShowMessage(updateResponse.ErrorMessage!);
                }
            }
            else
            {
                ShowMessage("Någonting gick fel, var god försök igen!");
            }
        }
        else
        {
            ShowMessage(getLocationResponse.ErrorMessage!);
        }
    }

    private GetLocationByLocationCodeResponse GetLocationResponse()
    {
        string locationCode = InputDialog("Platskoden för platsen du vill ändra namn på");

        GetLocationByLocationCodeResponse getLocationResponse = locationService.GetLocationByLocationCode(locationCode);
        return getLocationResponse;
    }

    private UpdateLocationResponse UpdateLocation(Location locationToUpdate)
    {
        UpdateLocationResponse updateResponse;
        string newLocationName = InputDialog($"Det namn du vill ersätta {locationToUpdate.LocationName} med");

        try
        {
            LocationName locationName = new LocationName(newLocationName);
            Location updatedLocation = new Location(locationToUpdate.LocationId, locationToUpdate.LocationCode, locationName);

            updateResponse = locationService.UpdateLocation(new UpdateLocationRequest(updatedLocation));
        }
        catch (Exception ex)
        {
            updateResponse = new UpdateLocationResponse(false, null, ex.Message);
        }

        return updateResponse;
    }

    private void ShowMessage(string message)
    {
        message = message ?? string.Empty;

        Console.WriteLine($"{message}");
        Console.WriteLine();
        Console.WriteLine($"Klicka på någon tangent för att fortsätta");
        Console.ReadKey();
    }
}
