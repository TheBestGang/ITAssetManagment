
namespace ITAssetManager.Domain.Assets.AssetInterfaces;
public interface IAssetDialogService
{
    public void WelcomeMessage();
    public void MainMenuMessage();
    public void AddAssetDialog();
    public void InactivateAssetDialog();
    public void PrintAllAssetsDialog();
    public void ErrorValidationMessage();


}
