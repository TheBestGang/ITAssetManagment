using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetManagerService(IInmemoryAssetRepository inMemoryAssetRepository, AssetModelLists _assetList, AssetDialogService assetDialogService, AssetModel asset) : IAssetManagerService
{
    public void AddAsset()
    {
        AssetModel newAsset = inMemoryAssetRepository.CreateAsset();

        //"Castar" min IEnumerable lista till en vanlig lista för att kunna lägga till på listan (???)
        var _assetList = (List<AssetModel>)AssetModelLists._assetList;
        _assetList.Add(newAsset);

        assetDialogService.AddedAssetAllDialog(newAsset.AssetName, newAsset.AssetSerialNumber, newAsset.AssetStatus);
    }

    public void InactiveAsset()
    {
        //skriv ut allt så användaren ser vad som ska göras
        assetDialogService.PrintAllAssetsDialog();
        inMemoryAssetRepository.ReadAssetList();

        //meddelande välj tillgång som ska inaktiveras
        assetDialogService.InactivateAssetDialog();

        //Hittar tillgången och ändrar status
        inMemoryAssetRepository.FindAssetToChange();

        //meddelande om att ändringen är utförd. 
        assetDialogService.ChangedAssetDialog();
    }
}
