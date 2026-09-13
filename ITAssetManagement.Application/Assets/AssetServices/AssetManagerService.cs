using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetManagerService(IInmemoryAssetRepository inMemoryAssetRepository, AssetModelLists _assetList) : IAssetManagerService
{
    public void AddAsset()
    {
        //Tillgång till assetModel
        AssetModel assetModel = new AssetModel();

        //Behöver ej skapa nytt guidId då det görs i modellen

        //Tillgång till assetDialog
        AssetDialogService assetDialogService = new AssetDialogService();


        //Validera input för name så det ej är tomt/null
        //SKRIV INPUT MESSAGE
        string userInputName = Console.ReadLine();
        bool validInputName = inMemoryAssetRepository.ValidateInput(userInputName);
        if (validInputName == true)
        {
            //Om validering ok läggs den till och skriver ut att den blev tillagd. 
            assetModel.AssetName = userInputName;
            assetDialogService.AddAssetNameDialog(userInputName);
        }

        //Serialnumber, samma som ovan hantering
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

        //"Castar" min IEnumerable lista till en vanlig lista för att kunna lägga till
        var _assetList = (List<AssetModel>)AssetModelLists._assetList;
        _assetList.Add(assetModel);
    }

    public void InactiveAsset()
    {
        throw new NotImplementedException();
    }
}
