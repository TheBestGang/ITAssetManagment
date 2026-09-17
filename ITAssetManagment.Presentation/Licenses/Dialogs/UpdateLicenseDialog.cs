using ITAssetManagement.Application.Licenses.Dtos;
using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManagment.Presentation.Licenses.Dialogs
{
    internal class UpdateLicenseDialog
    {
        public static UpdateLicenseRequest UpdateLicense()
        {
            Console.Clear();
            Console.WriteLine("Update a license");
            var licenseId = ConsoleInput.ReadRequiredString("License ID: ");
            var seatCountint = ConsoleInput.ReadNonNegativeInt("Seat Count: ");
            SeatCount seatCount = new(seatCountint);

            return new UpdateLicenseRequest(licenseId, seatCount);
        }
    }
}