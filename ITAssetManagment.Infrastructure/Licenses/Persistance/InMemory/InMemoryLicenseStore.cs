using ITAssetManager.Domain.Licenses.Models;

namespace ITAssetManagment.Infrastructure.Licenses.Persistance.InMemory;


internal class InMemoryLicenseStore : ILicenseStore
{
    private readonly List<License> _licenses = [];
    public bool AddLicense(License license)
    {
        ArgumentNullException.ThrowIfNull(license);
        _licenses.Add(license);
        return true;
    }
    public IReadOnlyList<License> GetAllLicenses()
    {
        return _licenses;
    }

    public License? GetLicenseByLicenseId(string licenseId)
    {
        ArgumentNullException.ThrowIfNull(licenseId);
        return _licenses.FirstOrDefault(x => x.LicenseId == licenseId);
    }
}
