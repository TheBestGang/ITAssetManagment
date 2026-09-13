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

        //Tillgång till assetDialog
        AssetDialogService assetDialogService = new AssetDialogService();

        //Validera input för name
        //SKRIV INPUT MESSAGE
        string userInputName = Console.ReadLine();
        bool validInputName = inMemoryAssetRepository.ValidateInput(userInputName);
        if (validInputName == true)
        {
            //Om validering ok läggs den till och skriver ut att den blev tillagd. 
            assetModel.AssetName = userInputName;
            assetDialogService.AddAssetNameDialog(userInputName);
        }

        //Serialnumber, samma som ovan teknik
        //SKRIV INPUT MESSAGE
        string userInputSerialNumber = Console.ReadLine();
        bool validInputSerialNumber = inMemoryAssetRepository.ValidateInput(userInputSerialNumber);
        if (validInputSerialNumber == true)
        {
            assetModel.AssetSerialNumber = userInputSerialNumber;
            assetDialogService.AddAssetSerialNumberDialog(userInputSerialNumber);
        }

        //Skriv ut allting som regisrerats
        assetDialogService.AddedAssetAllDialog(assetModel.AssetName, assetModel.AssetSerialNumber, assetModel.AssetStatus);

        //Listan och lägger till i listan
        AssetModelLists _assetList = new AssetModelLists();
        _assetList.Add(assetModel);
    }

    public void InactiveAsset()
    {
        throw new NotImplementedException();
    }
}
