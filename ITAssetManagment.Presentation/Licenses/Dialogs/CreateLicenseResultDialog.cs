using ITAssetManagement.Application.Licenses.Dtos;
using System.ComponentModel.Design;

namespace ITAssetManagment.Presentation.Licenses.Dialogs;

internal class CreateLicenseResultDialog
{
    internal static void ShowCreateLicenseResult(CreateLicenseResponse createLicenseResponse)
    {
        if (createLicenseResponse.Success && createLicenseResponse.License is not null)
        {
            Console.Clear();
            Console.WriteLine($"Licens skapad med ID: {createLicenseResponse.License.LicenseId}");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Skapandet av licens misslyckades: {createLicenseResponse.ErrorMessage}");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
            Console.ReadKey();
        }
    }
}
