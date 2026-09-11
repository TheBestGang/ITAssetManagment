
using ITAssetManager.Domain.Assets.AssetInterfaces;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetMenuService (IInmemoryAssetRepository inmemoryAssetRepository)
{
    public void DisplayAssetMenu()
    {
        bool runAssetMenu = true;
        do
        {
            //Välkomstmeddelande
            AssetDialogService dialogService = new AssetDialogService();
            dialogService.WelcomeMessage();

            //Menymeddelande
            dialogService.MainMenuMessage();

            
            //Validera input
            bool validInput = true;
            while (validInput)
            {
                string userInput = Console.ReadLine();
                validInput = inmemoryAssetRepository.ValidateInput(userInput);
            }

            string validUserInput = string.Empty;
            switch (validUserInput)
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
            }

        }while(runAssetMenu);
    }
}
