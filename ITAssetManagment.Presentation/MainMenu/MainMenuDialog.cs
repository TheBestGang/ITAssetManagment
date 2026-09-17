using ITAssetManagement.Application.Assets.AssetServices;
using ITAssetManagment.Presentation.Employees.Interfaces;
using ITAssetManagment.Presentation.Licenses;

namespace ITAssetManagment.Presentation.MainMenu;

internal class MainMenuDialog(IEmployeeDialog employeeDialog, AssetMenuService assetMenuService, LicenseMenu licenseMenu, LocationDialog locationDialog)
{
    public void RunDialog()
    {
        bool continueProgram = true;

        do
        {
            PrintMainMenu();
            int mainMenuChoice = GetUserChoice();
            continueProgram = HandleMainMenuChoice(mainMenuChoice);
        }
        while (continueProgram);
    }

    private void PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine("__________HUVUDMENY__________");
        Console.WriteLine();
        Console.WriteLine("1. Hantera IT-tillgångar");
        Console.WriteLine("2. Hantera medarbetare");
        Console.WriteLine("3. Hantera platser");
        Console.WriteLine("4. Hantera programvarulicenser");
        Console.WriteLine("0. Avsluta");
        Console.WriteLine();
        Console.Write("Ange ditt val: ");
    }

    private int GetUserChoice()
    {
        int menuChoice = -1;
        string choiceString = Console.ReadLine() ?? string.Empty;

        if (int.TryParse(choiceString, out int choice))
        {
            menuChoice = choice;
        }

        return menuChoice;
    }

    private bool HandleMainMenuChoice(int mainMenuChoice)
    {
        bool continueProgram = true;

        switch (mainMenuChoice)
        {
            case 1:
                assetMenuService.DisplayAssetMenu();
                break;

            case 2:
                employeeDialog.ShowMenu();
                break;

            case 3:
                locationDialog.RunLocationDialog();
                break;

            case 4:
                licenseMenu.HandleInput();
                break;

            case 0:
                continueProgram = false;
                PrintEndMessage();
                break;

            default:
                InvalidChoice();
                break;
        }

        return continueProgram;
    }

    private void InvalidChoice()
    {
        Console.Clear();
        Console.WriteLine("Ogiltigt menyval, välj mellan alternativ 0-4!");
        Console.WriteLine("Klicka på en tangent för att fortsätta");
        Console.ReadKey();
    }

    private void PrintEndMessage()
    {
        Console.Clear();
        Console.WriteLine("Ha en trevlig dag!");
        Console.ReadKey();
    }
}