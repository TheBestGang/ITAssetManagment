using ITAssetManager.Domain.Licenses.Models;

namespace ITAssetManagement.Application.Licenses.Dtos;

public record CreateLicenseResponse
(
    bool Success,
    License? License,
    string? ErrorMessage
    );
