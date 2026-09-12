using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManagement.Application.Licenses.Dtos;

public record UpdateLicenseRequest
(
    string LicenseId,
    SeatCount SeatCount
);