using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagement.Application.Assets.AssetServices;
public class AssetManagerService : IAssetManagerService
{
    public void AddAsset()
    {
        //Tillgången
        AssetModel assetModel = new AssetModel();
        assetModel.AssetId = Guid.NewGuid();
        assetModel.AssetId 
        //Listan
        AssetModelLists _assetList = new AssetModelLists();
        _assetList.Add();
    }

    public void InactiveAsset()
    {
        throw new NotImplementedException();
    }
}
