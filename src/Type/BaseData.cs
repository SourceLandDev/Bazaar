namespace SourceLand.Bazaar.Type;

public abstract class BaseData
{
    public required int Id { get; set; }
    public required int Count { get; set; }
    public required int Price { get; set; }
    public required string Owner { get; set; }
}