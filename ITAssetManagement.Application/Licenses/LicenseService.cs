using ITAssetManagement.Application.Licenses.Dtos;
using ITAssetManager.Domain.Licenses.Models;
using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManagement.Application.Licenses;

internal class LicenseService : ILicenseService
{
    public CreateLicenseResponse CreateLicense(CreateLicenseRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        string licenseId = Guid.NewGuid().ToString();
        Name productName = new Name(request.ProductName);
        LicenseReference licenseReference = new LicenseReference(request.LicenseReference);
        SeatCount seatCount = new SeatCount(request.SeatCount);

        License license = new(licenseId, productName, licenseReference, seatCount);
        var saved = licenseStore.Add(license);
        return saved
            ? new CreateLicenseResponse( true, license , null)
            : new CreateLicenseResponse ( false, null, ErrorMessage = "Failed to save the license." );  
    }

    public GetLicensesResponse GetAllLicenses()
    {
        throw new NotImplementedException();
    }

    public UpdateLicenseResponse UpdateLicense(UpdateLicenseRequest request)
    {
        throw new NotImplementedException();
    }
}
