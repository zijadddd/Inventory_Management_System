namespace server.Models.Out;
public record EmployeeOut {
    public string Id { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string DateOfEmployment { get; init; } = string.Empty;
    public string DateOfCancellation { get; init; } = string.Empty;
    public string UserId { get; init; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    public EmployeeOut(string id, string firstName, string lastName, string phoneNumber, string email, string dateOfEmployment, string dateOfCancellation, string userId, string username, string password, string role) {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        DateOfEmployment = dateOfEmployment;
        DateOfCancellation = dateOfCancellation;
        UserId = userId;
        Username = username;
        Password = password;
        Role = role;
    }
}
