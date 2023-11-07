namespace server.Models.Out;

public record SupplierOut {
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string UniqueIdentificationNumber { get; init; } = string.Empty;
    public string ValueAddedTax { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string ContactPerson { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string StartDate { get; init; } = string.Empty;
    public string EndDate { get; init; } = string.Empty;

    public SupplierOut(string id, string name, string uniqueIdentificationNumber, string valueAddedTax, string phoneNumber, string contactPerson, string email, string startDate, string endDate) {
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
