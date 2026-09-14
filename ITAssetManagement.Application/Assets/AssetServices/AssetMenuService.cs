
using ITAssetManager.Domain.Assets.AssetInterfaces;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetMenuService (IInmemoryAssetRepository inMemoryAssetRepository, AssetManagerService assetManagerService, AssetDialogService assetDialogService)
{
    public void DisplayAssetMenu()
    {
        assetDialogService.WelcomeMessage();

        bool runAssetMenu = true;
        do
        {
            assetDialogService.MainMenuMessage();

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1": //Registrera tillgång
                    {
                        assetManagerService.AddAsset();
                        break;
                    }
                case "2": //Avveckla tillgång (ej remove)
                    {
                        
                        break;
                    }
                case "3": //Skriv ut alla tillgångar
                    {

                        break;
                    }
                case "0": //avsluta hantering av assets
                    {
                        runAssetMenu = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Fel val. Tryck enter för att försöka igen");
                        Console.ReadKey();
                        break;
                    }
            }
        }while(runAssetMenu);
    }
}
