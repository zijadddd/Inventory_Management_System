using System.ComponentModel.DataAnnotations;

namespace server.Models.In;
public record EmployeeIn {
    [Required]
    [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Invalid first name. Valid: John")]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Invalid last name. Valid: Smith")]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^\(\+387\) [0-9]{2} [0-9]{3} [0-9]{3}$", ErrorMessage = "Invalid phone number. Valid: (+387) 60 128 0384")]
    public string PhoneNumber { get; set;} = string.Empty;
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address. Valid: johnsmith@gmail.com")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(64, MinimumLength = 8, ErrorMessage = "Invalid password. The password should be at least 8 characters long.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
    ErrorMessage = "Invalid password. Valid: Abcdef1*")]
    public string Password { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^[12]$", ErrorMessage = "Invalid role. Role Id must be 1 for Employee, 2 for Admin.")]
    public string RoleId { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid date. Valid: 2023-10-17")]
    public string DateOfEmployment { get; set; } = string.Empty;
}
