namespace server.Models.Entities;
public class User {
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
}
