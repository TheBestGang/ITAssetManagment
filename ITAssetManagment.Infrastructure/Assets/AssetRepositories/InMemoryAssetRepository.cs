
using ITAssetManager.Domain.Assets.AssetInterfaces;

namespace ITAssetManagment.Infrastructure.Assets.AssetRepositories;

public class InMemoryAssetRepository : IInmemoryAssetRepository
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
            Console.WriteLine("Du måste skriva någonting");
        }
        else
        {
            validInput = true;
        }

    }
}
