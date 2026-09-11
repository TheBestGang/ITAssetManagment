namespace ITAssetManagement.Application.Licenses.Dtos;

public record UpdateLicenseRequest
(
    string LicenseId,
    string SeatCount
);