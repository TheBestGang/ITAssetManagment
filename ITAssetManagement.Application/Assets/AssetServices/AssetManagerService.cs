using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetManagerService(IInmemoryAssetRepository inMemoryAssetRepository) : IAssetManagerService
{
    public void AddAsset()
    {
        //Tillgång till assetModel
        AssetModel assetModel = new AssetModel();
        //Skapa ID
        assetModel.AssetId = Guid.NewGuid();

        //Validera input för name
        //SKRIV IN INPUTMESSAGE
        string userInputName = Console.ReadLine();
        bool validInput = inMemoryAssetRepository.ValidateInput(userInputName);
        if (validInput == true)
        {
            assetModel.AssetName = userInputName;
            Console.WriteLine($"Tillgångens namn {userInputName} registrerat.");
        }
        
        //Serialnumber = ska skriva in

        //Skriv ut allting som regisrerats
        
        //Listan

        AssetModelLists _assetList = new AssetModelLists();
        _assetList.Add();
    }

    public void InactiveAsset()
    {
        throw new NotImplementedException();
    }
}
