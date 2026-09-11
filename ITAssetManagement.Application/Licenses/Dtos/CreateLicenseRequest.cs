using ITAssetManager.Domain.Licenses.Models;

namespace ITAssetManagement.Application.Licenses.Dtos;

public record CreateLicenseRequest
(
    
    string ProductName,
    string LicenseReference,
    int SeatCount
);
