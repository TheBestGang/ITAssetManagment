using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetManagerService(IInmemoryAssetRepository inMemoryAssetRepository, AssetModelLists _assetList) : IAssetManagerService
{
    public void AddAsset()
    {
        AssetModel newAsset = inMemoryAssetRepository.CreateAsset();

        //"Castar" min IEnumerable lista till en vanlig lista för att kunna lägga till
        var _assetList = (List<AssetModel>)AssetModelLists._assetList;
        _assetList.Add(newAsset);
    }

    public void InactiveAsset()
    {
        throw new NotImplementedException();
    }
}
