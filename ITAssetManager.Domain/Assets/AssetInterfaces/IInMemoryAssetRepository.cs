
namespace ITAssetManager.Domain.Assets.AssetInterfaces;

using ITAssetManager.Domain.Assets.AssetModels;

public interface IInmemoryAssetRepository
{
    public AssetModel CreateAsset();

    public void PrintAddedAsset(string assetName, string assetSerialNumber, bool assetStatus);

    public void InactivateAsset(string inputAssetSerialNumberToBeChanged);
    
    public void ReadAssetList();

    public bool ValidateInput(string userInput);
    public void FindAssetToChange();
}
