namespace SourceLand.Bazaar.Type;

public sealed class OfferData : BaseData
{
    public required string Type { get; set; }
    public required int Aux { get; set; }
    public List<(int, int)>? Enchantments { get; set; }
}