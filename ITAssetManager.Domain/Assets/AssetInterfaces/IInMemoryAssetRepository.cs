
namespace ITAssetManager.Domain.Assets.AssetInterfaces;

using ITAssetManager.Domain.Assets.AssetModels;

public interface IInmemoryAssetRepository
{
    public AssetModel CreateAsset();

    public void PrintAddedAsset(string addedAssetName, string addedAssetSerialNumber, bool addedAssetStatus);

    public void InactivateAsset(AssetModel asset);
    
    public void ReadAssetList();

    public bool ValidateInput(string userInput);
    public void FindAssetToChange();
}
