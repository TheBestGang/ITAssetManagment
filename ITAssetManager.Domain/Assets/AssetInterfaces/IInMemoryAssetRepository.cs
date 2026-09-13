
namespace ITAssetManager.Domain.Assets.AssetInterfaces;
public interface IInmemoryAssetRepository
{
    public void CreateAsset();

    public void PrintAddedAsset(string assetName, string assetSerialNumber, bool assetStatus);

    public void InactivateAsset();
    
    public void ReadAssetList();

    public bool ValidateInput(string userInput);
}
