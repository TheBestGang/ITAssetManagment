using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetManagerService(IInmemoryAssetRepository inMemoryAssetRepository, AssetModelLists _assetList, AssetDialogService assetDialogService, AssetModel asset) : IAssetManagerService
{
    public void AddAsset()
    {
        AssetModel newAsset = inMemoryAssetRepository.CreateAsset();

        //"Castar" min IEnumerable lista till en vanlig lista för att kunna lägga till på listan
        var _assetList = (List<AssetModel>)AssetModelLists._assetList;
        _assetList.Add(newAsset);
    }

    public void InactiveAsset(AssetModel asset)
    {
        //skriv ut allt
        assetDialogService.PrintAllAssetsDialog();

        //meddelande välj tillgång som ska inaktiveras
        assetDialogService.InactivateAssetDialog();

        //Lägg till en sökning av det användaren skrivit in + koppla till repon för denna ändring. 

        //Ändra bool till false
        asset.AssetStatus = false;

    }
}
