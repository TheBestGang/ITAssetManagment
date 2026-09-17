namespace ITAssetManagment.Presentation.Licenses.Dialogs;
using ITAssetManagement.Application.Licenses.Dtos;


internal class CreateLicenseDialog
{
    public static CreateLicenseRequest CreateLicense()
    {
        Console.Clear();
        Console.WriteLine("Create a new license");

        var productName = ConsoleInput.ReadRequiredString("Product name: ");
        var licenseReference = ConsoleInput.ReadRequiredString("License reference: ");
        var seatCount = ConsoleInput.ReadNonNegativeInt("Seat count: ");

        return new CreateLicenseRequest(
            productName,
            licenseReference,
            seatCount);
    }
}



