using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetManagerService(IInmemoryAssetRepository inMemoryAssetRepository, AssetModelLists _assetList) : IAssetManagerService
{
    public void AddAsset()
    {

        inMemoryAssetRepository.CreateAsset();

        AssetDialogService assetDialogService = new AssetDialogService();
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
