
using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagment.Infrastructure.Assets.AssetRepositories;

public class InMemoryAssetRepository(IAssetDialogService dialogService) : IInmemoryAssetRepository 
{
    public void CreateAsset()
    {
        //Tillgång till assetModel
        AssetModel assetModel = new AssetModel();

        //Behöver ej skapa nytt guidId då det görs i modellen

        //Validera input för name så det ej är tomt/null
        //SKRIV INPUT MESSAGE
        string userInputName = Console.ReadLine();
        bool validInputName = ValidateInput(userInputName);
        if (validInputName == true)
        {
            //Om validering ok läggs den till och skriver ut att den blev tillagd. 
            assetModel.AssetName = userInputName;
            dialogService.AddAssetNameDialog(userInputName);
        }

        //Serialnumber, samma som ovan hantering
        //SKRIV INPUT MESSAGE
        string userInputSerialNumber = Console.ReadLine();
        bool validInputSerialNumber = ValidateInput(userInputSerialNumber);
        if (validInputSerialNumber == true)
        {
            assetModel.AssetSerialNumber = userInputSerialNumber;
            dialogService.AddAssetSerialNumberDialog(userInputSerialNumber);
        }

        //PrintAddedAsset(assetModel.AssetName, assetModel.AssetSerialNumber, assetModel.AssetStatus);

    }

    //public void PrintAddedAsset(string assetName, string assetSerialNumber, bool assetStatus)
    {
        //Skriv ut allting som regisrerats
        
        
        
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
