
using ITAssetManager.Domain.Assets.AssetInterfaces;

namespace ITAssetManagement.Application.Assets.AssetServices;

public class AssetDialogService(IInmemoryAssetRepository inMemoryAssetRepository) : IAssetDialogService
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
        //Printar ut allt
        inMemoryAssetRepository.PrintAddedAsset(addedAssetName, addedAssetSerialNumber, addedAssetStatus);

        Console.WriteLine("Tryck valrfri tangent för att fortsätta");
        Console.ReadKey();
        Console.Clear();
    }



    public void ErrorValidationMessage()
    {
        Console.WriteLine("Felaktig inmatning, försök igen");
    }



    public void InactivateAssetDialog()
    {
        Console.WriteLine("Skriv serienummer på den tillgången du vill ändra status på");
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
        Console.WriteLine("Samtliga tillgångar du sparat: \n" +
                          "_______________________________");
    }



    public void WelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine("Välkommen till hantering av tillgångar. Tryck valfri tangent för att gå vidare");
        Console.ReadKey();
    }

    public void InputRequestMessage(string input)
    {
        Console.WriteLine($"Vänligen ange tillgångens {input}: ");
    }

}
