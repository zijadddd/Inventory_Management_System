using Microsoft.EntityFrameworkCore;
using server.Models.Entities;
using server.Models.In;

namespace server.Database;
public class DatabaseContext : DbContext {

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<RawMaterial> RawMaterials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Employee" }, new Role { Id = 2, Name = "Admin" });
        modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, FirstName = "Admin", LastName = "Admin", Email = "company@provider.com", PhoneNumber = "(+387) 00 000 0000" });
        modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin"), EmployeeId = 1, RoleId = 2 });
    }
}
