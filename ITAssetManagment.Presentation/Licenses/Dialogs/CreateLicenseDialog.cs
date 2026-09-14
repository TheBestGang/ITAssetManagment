namespace ITAssetManagment.Presentation.Licenses.Dialogs;
using ITAssetManagement.Application.Licenses.Dtos;


internal class CreateLicenseDialog
{
    public static CreateLicenseRequest CreateLicense()
    {
        Console.Clear();
        Console.WriteLine("###Skapa ny licens###");

        var productName = ConsoleInput.ReadRequiredString("Produktnamn: ");
        var licenseReference = ConsoleInput.ReadRequiredString("Licensreferens: ");
        var seatCount = ConsoleInput.ReadNonNegativeInt("Antal platser: ");
        return new CreateLicenseRequest(
            productName,
            licenseReference,
            seatCount);
    }
}



