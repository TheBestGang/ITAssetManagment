using ITAssetManagement.Application.Licenses;
using ITAssetManagement.Application.Licenses.Dtos;
using ITAssetManagment.Presentation.Licenses.Dialogs;

namespace ITAssetManagment.Presentation.Licenses;

internal class LicenseMenu
{
    public static void Show()
    {
        Console.Clear();
        Console.WriteLine("###Licensmeny###");
        Console.WriteLine("1. Lägg till en ny licens");
        Console.WriteLine("2. Visa alla licenser");
        Console.WriteLine("0. Tillbaka till huvudmeny");
    }
    public static void HandleInput()
    {
        while (true)
        {
            Show();
            Console.Write("Välj ett alternativ: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateLicenseDialog.CreateLicense();
                    break;
                case "2":
                    ShowAllLicensesDialog.ShowAllLicenses();

                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

