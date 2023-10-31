namespace server.Models.Entities;

public class RawMaterial
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int MinQuantity { get; set; } 
    public int Price { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
    public bool InUsage { get; set; } 
    public int SupplierId { get; set; } 
    public Supplier? Supplier { get; set; }
}
