using ITAssetManager.Domain.Licenses.Models;
using ITAssetManager.Domain.Licenses.ValueObjects;
using static System.Reflection.Metadata.BlobBuilder;

namespace ITAssetManagment.Infrastructure.Licenses.Persistance.InMemory;


internal class InMemoryLicenseStore : ILicenseStore
{
    public readonly List<License> _licenses = [];

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

    public bool UpdateLicense(string licenseId, SeatCount newSeatCount, out SeatCount seatCount)
    {
        GetLicenseByLicenseId(licenseId, out var license);
        if (license == null)
        {
            seatCount = null;
            return false;
        }
        var index = _licenses.IndexOf(license);
        if (index > -1)
        {
            _licenses[index].SeatCount = newSeatCount;
        }
        seatCount = newSeatCount;
        return true;
    }
    public License GetLicenseByLicenseId(string licenseId, out License license)
    {
        ArgumentNullException.ThrowIfNull(licenseId, nameof(licenseId));
        license = _licenses.FirstOrDefault(x => x.LicenseId == licenseId);
        return license;
    }
}
