using ITAssetManager.Domain.Licenses.Models;

namespace ITAssetManagement.Application.Licenses.Dtos;

public record GetLicensesResponse
(
    bool Success,
    IEnumerable<License> Licenses,
    string? ErrorMessage
    );
