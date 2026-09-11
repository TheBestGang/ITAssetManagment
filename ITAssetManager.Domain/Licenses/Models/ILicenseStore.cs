using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManager.Domain.Licenses.Models;

public interface ILicenseStore
{
    bool AddLicense(License license);
    IReadOnlyList<License> GetAllLicenses();
    bool UpdateLicense(string licenseId, SeatCount newSeatCount, out SeatCount seatCount);
    License GetLicenseByLicenseId(string licenseId, out License license);
}