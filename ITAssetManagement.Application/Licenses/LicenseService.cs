using ITAssetManagement.Application.Licenses.Dtos;
using ITAssetManager.Domain.Licenses.Models;
using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManagement.Application.Licenses;

public class LicenseService : ILicenseService
{
    private readonly ILicenseStore _licenseStore;

    public LicenseService(ILicenseStore licenseStore)
    {
        _licenseStore = licenseStore;
    }

    public CreateLicenseResponse CreateLicense(CreateLicenseRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        string licenseId = Guid.NewGuid().ToString();
        Name productName = new Name(request.ProductName);
        LicenseReference licenseReference = new LicenseReference(request.LicenseReference);
        SeatCount seatCount = new SeatCount(request.SeatCount);

        License license = new(licenseId, productName, licenseReference, seatCount);
        var saved = _licenseStore.AddLicense(license);

        return saved
            ? new CreateLicenseResponse(true, license, null)
            : new CreateLicenseResponse(false, null, "Misslyckades med att spara licensen.");
    }


    public GetLicensesResponse GetAllLicenses()
    {
        var licenses = _licenseStore.GetAllLicenses();

        return new GetLicensesResponse(true, licenses, null);
    }
    public UpdateLicenseResponse UpdateLicense(UpdateLicenseRequest request)
    {
        if (request == null)
        {
            return new UpdateLicenseResponse(false, null, "Felaktig begäran");
        }

        var license = _licenseStore.GetLicenseByLicenseId(request.LicenseId);
        if (license == null)
        {
            return new UpdateLicenseResponse(false, null, "Licensen hittades inte.");
        }
        license.SeatCount = request.SeatCount;
        return new UpdateLicenseResponse(true, license.SeatCount, null);
    }
}
