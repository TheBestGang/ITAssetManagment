using ITAssetManagement.Application.Licenses;
using ITAssetManagement.Application.Licenses.Dtos;
using ITAssetManagment.Presentation.Licenses.Dialogs;

namespace ITAssetManagment.Presentation.Licenses;

internal class LicenseMenu(ILicenseService licenseService)
{
    private readonly ILicenseService _licenseService = licenseService;

    public static void Show()
    {
        Console.Clear();
        Console.WriteLine("###Licensmeny###");
        Console.WriteLine("1. Lägg till en ny licens");
        Console.WriteLine("2. Visa alla licenser");
        Console.WriteLine("3. Uppdatera licens");
        Console.WriteLine("0. Tillbaka till huvudmeny");
    }
    public void HandleInput()
    {
        while (true)
        {
            Show();
            Console.Write("Välj ett alternativ: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    var createRequest = CreateLicenseDialog.CreateLicense();
                    var createResponse = _licenseService.CreateLicense(createRequest);
                    CreateLicenseResultDialog.ShowCreateLicenseResult(createResponse);
                    break;
                case "2":
                    var getAllResponse = _licenseService.GetAllLicenses();
                    ShowAllLicensesDialog.ShowAllLicenses(getAllResponse);
                    break;
                case "3":
                    var updateRequest = UpdateLicenseDialog.UpdateLicense();
                    var updateResponse = _licenseService.UpdateLicense(updateRequest);
                    UpdateLicenseResultDialog.ShowUpdateLicenseResult(updateResponse);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Ogiltigt värde. Försök igen.");
                    break;
            }
        }
    }
}