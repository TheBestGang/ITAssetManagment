using ITAssetManagement.Application.Licenses.Dtos;
using System.ComponentModel.Design;

namespace ITAssetManagment.Presentation.Licenses.Dialogs;

internal class UpdateLicenseResultDialog
{
    internal static void ShowUpdateLicenseResult(UpdateLicenseResponse updateLicenseResponse)
    {
        if (updateLicenseResponse.Success && updateLicenseResponse.SeatCount is not null)
        {
            Console.Clear();
            Console.WriteLine($"Antal uppdaterat till: {updateLicenseResponse.SeatCount}");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Uppdateringen misslyckades: {updateLicenseResponse.ErrorMessage}");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
            Console.ReadKey();
        }
    }
}
