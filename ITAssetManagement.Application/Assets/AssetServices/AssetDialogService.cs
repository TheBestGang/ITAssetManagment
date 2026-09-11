
using ITAssetManager.Domain.Assets.AssetInterfaces;

namespace ITAssetManagement.Application.Assets.AssetServices;

public class AssetDialogService : IAssetDialogService
{
    public void AddAssetDialog()
    {
        throw new NotImplementedException();
    }

    public void ErrorValidationMessage()
    {
        throw new NotImplementedException();
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
