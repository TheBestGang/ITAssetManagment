
using ITAssetManager.Domain.Assets.AssetInterfaces;

namespace ITAssetManagment.Infrastructure.Assets.AssetRepositories;

public class InMemoryAssetRepository(IAssetDialogService dialogService) : IInmemoryAssetRepository 
{
    public void CreateAsset()
    {
        throw new NotImplementedException();
    }

    public void InactivateAsset()
    {
        throw new NotImplementedException();
    }

    public void ReadAssetList()
    {
        throw new NotImplementedException();
    }

    public bool ValidateInput(string userInput)
    {
        bool validInput = false;
        if (string.IsNullOrWhiteSpace(userInput))
        {
            dialogService.ErrorValidationMessage();
            validInput = false;
        }
        else
        {
            validInput = true;
        }
        return validInput;
    }
}
