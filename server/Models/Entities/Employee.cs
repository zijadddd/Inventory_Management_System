﻿namespace server.Models.Entities;
public class Employee {
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfEmployment { get; set; }
    public DateTime DateOfCancellation { get; set; }
    public User? User { get; set; }
}
