
namespace ITAssetManager.Domain.Assets.AssetInterfaces;
public interface IAssetDialogService
{
    public void WelcomeMessage();
    public void MainMenuMessage();
    public void AddAssetNameDialog(string addedAssetName);
    public void AddAssetSerialNumberDialog(string assetSerialNumber);
    public void AddedAssetAllDialog(string addedAssetName, string addedAssetSerialNumber, bool addedAssetStatus);
    public void InactivateAssetDialog();
    public void PrintAllAssetsDialog();
    public void ErrorValidationMessage();
    public void InputRequestMessage(string input);


}
