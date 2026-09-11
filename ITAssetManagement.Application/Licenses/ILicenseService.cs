namespace ITAssetManagement.Application.Licenses;

public interface ILicenseService
{
    CreateLicenseRespose CreateLicense(CreateLicenseRequest request);
    GetLicenseResponse GetAllLicenses();
}
