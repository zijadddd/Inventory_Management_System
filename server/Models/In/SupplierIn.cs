using System.ComponentModel.DataAnnotations;

namespace server.Models.In;

public record SupplierIn {
    [Required]
    [RegularExpression(@"^[A-Z][a-zA-Z0-9]*(\s*[A-Z][a-zA-Z0-9]*\.?)*$", ErrorMessage = "Invalid name. Valid: Supplier D.O.O")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^\d{13}$", ErrorMessage = "Invalid unique identification number. Valid: 1305986712345")]
    public string UniqueIdentificationNumber { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^(100(\.0{1,2})?|(\d{1,2}(\.\d{1,2})?|\d{0,1}\.\d{1,2}))$", ErrorMessage = "Invalid value added tax. Valid: 18")]
    public string ValueAddedTax { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^\(\+387\) \d{8,9}$", ErrorMessage = "Invalid phone number. Valid: (+387) 64498123 or (+387) 644981234")]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Invalid contact person name. Valid: John")]
    public string ContactPerson { get; set; } = string.Empty;
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address. Valid: johnsmith@gmail.com")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid start date. Valid: 2023-10-17")]
    public string StartDate { get; set; } = string.Empty;
    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid end date. Valid: 2023-10-17")]
    public string EndDate { get; set; } = string.Empty;
}
