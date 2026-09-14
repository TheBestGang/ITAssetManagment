
using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagment.Infrastructure.Assets.AssetRepositories;

public class InMemoryAssetRepository(IAssetDialogService dialogService) : IInmemoryAssetRepository 
{
    public AssetModel CreateAsset()
    {
        AssetModel assetModel = new AssetModel();

        //Behöver ej skapa nytt guidId då det görs i modellen

        //Efterfrågar och tilldelar tillgångsnamn + validering
        string namnInput = "namn";
        dialogService.InputRequestMessage(namnInput);

        string userInputName = Console.ReadLine();
        bool validInputName = ValidateInput(userInputName);
        if (validInputName == true)
        {
            //Om validering ok läggs den till och skriver ut att den blev tillagd. 
            assetModel.AssetName = userInputName;
            dialogService.AddAssetNameDialog(userInputName);
        }

        //Serienummer, samma som ovan hantering

        string serienummerInput = "serienummer";
        dialogService.InputRequestMessage(serienummerInput);

        string userInputSerialNumber = Console.ReadLine();
        bool validInputSerialNumber = ValidateInput(userInputSerialNumber);
        if (validInputSerialNumber == true)
        {
            assetModel.AssetSerialNumber = userInputSerialNumber;
            dialogService.AddAssetSerialNumberDialog(userInputSerialNumber);
        }

        return assetModel;
    }

    public void PrintAddedAsset(string addedAssetName, string addedAssetSerialNumber, bool addedAssetStatus)
    {
        if (addedAssetStatus == true)
        {
            //Skitdum hantering för att ändra status till "Aktiv" inför utskrift.
            string assetStatus = "Aktiv";

            //Skriv ut allting som regisrerats
            Console.WriteLine($"Tillgång tillagd med följande information: \n" +
                              $"Namn: {addedAssetName}\n" +
                              $"Serienummer: {addedAssetSerialNumber}\n" +
                              $"Status: {assetStatus}\n");
        }
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
