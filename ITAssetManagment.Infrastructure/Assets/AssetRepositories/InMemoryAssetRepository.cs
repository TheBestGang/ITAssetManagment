
using ITAssetManager.Domain.Assets.AssetInterfaces;
using ITAssetManager.Domain.Assets.AssetModels;

namespace ITAssetManagment.Infrastructure.Assets.AssetRepositories;

public class InMemoryAssetRepository(IAssetDialogService dialogService, AssetModel asset, AssetModelLists _assetList) : IInmemoryAssetRepository 
{
    public AssetModel CreateAsset()
    {
        AssetModel assetModel = new AssetModel();

        //Behöver ej skapa nytt guidId då det görs i modellen

        bool validInputName = false;

        while (validInputName == false)
        {
            //Efterfrågar och tilldelar tillgångsnamn + validering
            string namnInput = "namn";
            dialogService.InputRequestMessage(namnInput);

            string userInputName = Console.ReadLine();
            validInputName = ValidateInput(userInputName);

            if (validInputName == true)
            {
                //Om validering ok läggs den till och skriver ut att den blev tillagd. 
                assetModel.AssetName = userInputName;
                dialogService.AddAssetNameDialog(userInputName);
            }
            else
            {
                Console.ReadKey();
            }
        }


        //Serienummer, samma som ovan hantering

        bool validInputSerialNumber = false;

        while (validInputSerialNumber == false)
        {
            string serienummerInput = "serienummer";
            dialogService.InputRequestMessage(serienummerInput);

            string userInputSerialNumber = Console.ReadLine();
            validInputSerialNumber = ValidateInput(userInputSerialNumber);

            if (validInputSerialNumber == true)
            {
                //lägger till validering om serienummer redan finns

                bool notFoundSerialNumber = FindAssetSerialNumber(userInputSerialNumber);

                if (notFoundSerialNumber == false)
                {
                    Console.WriteLine("Tillgång med det serienumret finns redan, tryck valfri tangent för att försöka igen");
                    Console.ReadKey();
                }
                else
                {
                    assetModel.AssetSerialNumber = userInputSerialNumber;
                    dialogService.AddAssetSerialNumberDialog(userInputSerialNumber);
                }
            }
            else
            {
                Console.ReadKey();
                validInputSerialNumber = false;
            }
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
            Console.Clear();
            Console.WriteLine($"Tillgång tillagd med följande information: \n" +
                              $"Namn:\t\t {addedAssetName}\n" +
                              $"Serienummer:\t {addedAssetSerialNumber}\n" +
                              $"Status:\t\t {assetStatus}\n");
        }
    }

    public void InactivateAsset(AssetModel asset)
    {
        if (asset.AssetStatus == true)
        {
            asset.AssetStatus = false;
        }
        else
        {
            asset.AssetStatus = true;
        }
    }

    public void FindAssetToChange()
    {
        string inputAssetSerialNumberToBeChanged = Console.ReadLine();

        bool validInput = ValidateInput(inputAssetSerialNumberToBeChanged);

        if (validInput == true)
        {
            //Castar fram min lista för användning (???)
            var _assetList = (List<AssetModel>)AssetModelLists._assetList;

            foreach (AssetModel existingAsset in _assetList)
            {
                if (inputAssetSerialNumberToBeChanged == existingAsset.AssetSerialNumber)
                {
                    InactivateAsset(existingAsset);
                }
            }
        }
        else
        {
            dialogService.ErrorValidationMessage();
        }
    }

    //Jag vet att denna bör kunna kombineras med ovanstående men {tidsbrist}
    public bool FindAssetSerialNumber(string inputAssetSerialNumberToFind)
    {
        bool validInput = ValidateInput(inputAssetSerialNumberToFind);

        if (validInput == true)
        {
            var _assetList = (List<AssetModel>)AssetModelLists._assetList;
            foreach (AssetModel existingAsset in _assetList)
            {
                if (inputAssetSerialNumberToFind == existingAsset.AssetSerialNumber)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReadAssetList()
    {
        if (_assetList != null)
        {
            foreach (AssetModel asset in AssetModelLists._assetList)
            {
                //Skämssätt att sätta aktiv eller inaktiv på statusen
                string assetStatus;
                if (asset.AssetStatus == true)
                {
                    assetStatus = "Aktiv";
                }
                else
                {
                    assetStatus = "Inaktiv";
                }
                Console.WriteLine($"\nTillgång: \n" +
                                  $"Namn: {asset.AssetName}\n" +
                                  $"Serienummer: {asset.AssetSerialNumber}\n" +
                                  $"Status: {assetStatus}");
            }
            Console.WriteLine("\nTryck valrfri tangent för att fortsätta");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Du har inga tillgångar i din lista");
            Console.ReadKey();
        }
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
