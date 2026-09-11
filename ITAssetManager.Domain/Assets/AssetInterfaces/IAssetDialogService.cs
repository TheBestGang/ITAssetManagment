
namespace ITAssetManager.Domain.Assets.AssetInterfaces;
public interface IAssetDialogService
{
    public void WelcomeMessage();
    public void MainMenuMessage();
    public void AddAssetDialog();
    public void ManageAssetDialog();
    public void PrintAllAssetsDialog();
    public void ErrorValidationMessage();


}
