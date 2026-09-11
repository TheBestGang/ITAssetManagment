using ITAssetManagement.Application.Licenses.Dtos;

namespace ITAssetManagement.Application.Licenses;

public interface ILicenseService
{
    CreateLicenseResponse CreateLicense(CreateLicenseRequest request);
    GetLicensesResponse GetAllLicenses();
    UpdateLicenseResponse UpdateLicense(UpdateLicenseRequest request);
}
