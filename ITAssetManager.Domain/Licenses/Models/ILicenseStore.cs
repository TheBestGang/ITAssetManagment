using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManager.Domain.Licenses.Models;

public interface ILicenseStore
{
    bool AddLicense(License license);
    IReadOnlyList<License> GetAllLicenses();
    License? GetLicenseByLicenseId(string licenseId);
}
