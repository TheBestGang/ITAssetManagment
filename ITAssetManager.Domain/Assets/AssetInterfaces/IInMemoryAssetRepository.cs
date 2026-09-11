
namespace ITAssetManager.Domain.Assets.AssetInterfaces;
public interface IInmemoryAssetRepository
{
    public void CreateAsset();

    public void InactivateAsset();
    
    public void ReadAssetList();

    public bool ValidateInput(string userInput);
}
