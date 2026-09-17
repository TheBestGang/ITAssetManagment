using ITAssetManager.Domain.Licenses.Models;
using ITAssetManager.Domain.Licenses.ValueObjects;

namespace ITAssetManagement.Application.Licenses.Dtos;

public record UpdateLicenseResponse
(
    bool Success,
    SeatCount? SeatCount,
    string? ErrorMessage
    );