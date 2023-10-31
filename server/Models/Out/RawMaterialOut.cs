namespace server.Models.Out;

public class RawMaterialOut
{
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Quantity { get; init; } = string.Empty;
    public string MinQuantity { get; init; } = string.Empty;
    public string Price { get; init; } = string.Empty;
    public string UnitOfMeasure { get; init; } = string.Empty;
    public string InUsage { get; init; } = string.Empty;
    public string SupplierId { get; init; } = string.Empty;

    public RawMaterialOut(string id, string name, string quantity, string minQuantity, string price, string unitOfMeasure, string inUsage, string supplierId)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        MinQuantity = minQuantity;
        Price = price;
        UnitOfMeasure = unitOfMeasure;
        InUsage = inUsage;
        SupplierId = supplierId;
    }
}
