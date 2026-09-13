
using ITAssetManager.Domain.Assets.AssetInterfaces;

namespace ITAssetManagement.Application.Assets.AssetServices;

public class AssetDialogService : IAssetDialogService
{
    public void AddAssetNameDialog(string addedAssetName)
    {
        Console.WriteLine($"Tillgången {addedAssetName} är tillagd!");
    }

    public void AddAssetSerialNumberDialog(string addedAssetSerialNumber)
    {
        Console.WriteLine($"Tillgångens serienummer {addedAssetSerialNumber} är tillagd!");
    }

    public void AddedAssetAllDialog(string addedAssetName, string addedAssetSerialNumber, bool addedAssetStatus)
    {
        if (addedAssetStatus == true)
        {
            //Skitdum hantering för att ändra status till "Aktiv" inför utskrift.
            string assetStatus = "Aktiv";

            Console.WriteLine($"Tillgång tillagd med följande information: \n" +
                          $"Namn: {addedAssetName}\n" +
                          $"Serienummer: {addedAssetSerialNumber}\n" +
                          $"Status: {assetStatus}\n");
        }
        Console.WriteLine("Tryck valrfri tangent för att fortsätta");
    }

    public void ErrorValidationMessage()
    {
        Console.WriteLine("Felaktig inmatning, försök igen");
    }

    public void InactivateAssetDialog()
    {
        throw new NotImplementedException();
    }

    public void MainMenuMessage()
    {
        Console.Clear();
        Console.WriteLine("___________MENY TILLGÅNGAR___________\n" +
                          "Välj det du vill göra: \n\n" +
                          "[1] Lägg till en tillgång\n" +
                          "[2] Inaktivera en tillgång\n" +
                          "[3] Skriv ut alla sparade tillgångar\n" +
                          "[0] Gå tillbaka till huvudmenyn");
    }

    public void PrintAllAssetsDialog()
    {
        throw new NotImplementedException();
    }

    public void WelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine("Välkommen till hantering av tillgångar. Tryck valfri tangent för att gå vidare");
        Console.ReadKey();
    }
}
