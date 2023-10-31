namespace server.Models.In;

public record RawMaterialIn {
    public string Name { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string MinQuantity { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public string InUsage { get; set; } = string.Empty;
    public string SupplierId { get; set; } = string.Empty;
}
