using ITAssetManagement.Application.Licenses.Dtos;
using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManagment.Presentation.Licenses.Dialogs
{
    internal class UpdateLicenseDialog
    {
        public static UpdateLicenseRequest UpdateLicense()
        {
            Console.Clear();
            Console.WriteLine("###Uppdatera licens###");
            var licenseId = ConsoleInput.ReadRequiredString("Licens ID: ");
            var seatCountint = ConsoleInput.ReadNonNegativeInt("Antal platser: ");
            SeatCount seatCount = new(seatCountint);

            return new UpdateLicenseRequest(licenseId, seatCount);
        }
    }
}