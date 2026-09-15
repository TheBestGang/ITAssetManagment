
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManager.Domain.Assets.AssetInterfaces;
public interface IAssetManagerService
{
    public void AddAsset();
    public void InactiveAsset(AssetModel asset);
}
