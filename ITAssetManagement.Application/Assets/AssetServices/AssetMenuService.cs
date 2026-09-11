
namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetMenuService
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

            //Valdera input

            string userInput = string.Empty;
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
            }

        }while(runAssetMenu);
    }
}
