
namespace ITAssetManager.Domain.Assets.AssetModels;
public class AssetModel
{
    public Guid AssetId { get; set; } = Guid.NewGuid();
    public string AssetName { get; set; } = string.Empty;
    public string AssetSerialNumber { get; set; } = string.Empty;
    public bool AssetStatus { get; set; } = true;
}
