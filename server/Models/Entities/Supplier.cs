namespace server.Models.Entities;

public class Supplier {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UniqueIdentificationNumber { get; set; } = string.Empty;
    public double ValueAddedTax { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<RawMaterial>? RawMaterials { get; set; }
}
