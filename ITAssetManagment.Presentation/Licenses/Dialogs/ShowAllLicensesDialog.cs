using ITAssetManagement.Application.Licenses;
using ITAssetManagement.Application.Licenses.Dtos;
using ITAssetManager.Domain.Licenses.Models;

namespace ITAssetManagment.Presentation.Licenses.Dialogs
{
    internal class ShowAllLicensesDialog
    {
        public static void ShowAllLicenses(GetLicensesResponse response)
        {
            foreach (var license in response.Licenses)
            {
                Console.WriteLine($"Licens ID: {license.LicenseId}, Namn: {license.ProductName.Value}, Referens: {license.LicenseReference.Value}, Antal användare: {license.SeatCount.Value}");    
                Console.ReadKey();
            }
        }
    }
}