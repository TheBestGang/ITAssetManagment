
using ITAssetManager.Domain.Assets.AssetInterfaces;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetMenuService (IInmemoryAssetRepository inmemoryAssetRepository)
{
    public void DisplayAssetMenu()
    {
        AssetDialogService dialogService = new AssetDialogService();
        dialogService.WelcomeMessage();

        bool runAssetMenu = true;
        do
        {
            dialogService.MainMenuMessage();

            //Validera input med valideringsmetod
            //bool validInput = inmemoryAssetRepository.ValidateInput(Console.ReadLine());

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1": //Registrera tillgång
                    {

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
