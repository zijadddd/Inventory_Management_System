namespace server.Models.Out;

public record SupplierOut
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string UniqueIdentificationNumber { get; set; } = string.Empty;
    public string ValueAddedTax { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;

    public SupplierOut(string id, string name, string uniqueIdentificationNumber, string valueAddedTax, string phoneNumber, string contactPerson, string email, string startDate, string endDate)
    {
        Id = id;
        Name = name;
        UniqueIdentificationNumber = uniqueIdentificationNumber;
        ValueAddedTax = valueAddedTax;
        PhoneNumber = phoneNumber;
        ContactPerson = contactPerson;
        Email = email;
        StartDate = startDate;
        EndDate = endDate;
    }
}
