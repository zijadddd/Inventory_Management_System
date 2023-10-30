using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Database;
using server.Models.DTOs;
using server.Models.Entities;
using server.Models.In;
using server.Models.Out;
using server.Services.Interfaces;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server.Services.Implementations;
public class UserService : IUserService {

    private readonly DatabaseContext _databaseContext;
    private readonly IConfiguration _configuration;

    public UserService(DatabaseContext databaseContext, IConfiguration configuration)
    {
        _databaseContext = databaseContext;
        _configuration = configuration;
    }

    public async Task<dynamic> RegisterAnEmployee(EmployeeIn employeeIn) {
        try {
            var roles = await _databaseContext.Roles.ToListAsync();
            var username = $"{employeeIn.FirstName.ToLower()}_{employeeIn.LastName.ToLower()}_{employeeIn.DateOfEmployment.Substring(0, 4)}";

            Employee employee = new Employee {
                FirstName = employeeIn.FirstName,
                LastName = employeeIn.LastName,
                PhoneNumber = employeeIn.PhoneNumber,
                Email = employeeIn.Email,
                DateOfEmployment = DateTime.Parse(employeeIn.DateOfEmployment)
            };

            await _databaseContext.AddAsync(employee);

            User user = new User {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(employeeIn.Password),
                Role = roles.Where(r => r.Id == int.Parse(employeeIn.RoleId)).FirstOrDefault(),
                Employee = employee
            };

            await _databaseContext.Users.AddAsync(user);
            await _databaseContext.SaveChangesAsync();

            return new EmployeeOut(employee.Id.ToString(), employee.FirstName, employee.LastName, employee.PhoneNumber, employee.Email, 
                employee.DateOfEmployment.ToString(), employee.DateOfCancellation.ToString(), user.Id.ToString(), user.Username, user.Password, user.Role.Name);

        } catch (Exception ex) {
            return ex.Message;
        }

    }

    public async Task<dynamic> AuthenticateUser(UserAuthInfoDto userAuthInfoDto)
    {
        try
        {
            var userExist = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Username.Equals(userAuthInfoDto.Username));

            userExist.Role = await _databaseContext.Roles.FirstOrDefaultAsync(r => r.Id == userExist.RoleId);
            userExist.Employee = await _databaseContext.Employees.FirstOrDefaultAsync(e => e.Id == userExist.EmployeeId);

            if (userExist == null) throw new Exception($"User with {userAuthInfoDto.Username} username not found.");
            if (!BCrypt.Net.BCrypt.Verify(userAuthInfoDto.Password, userExist.Password)) throw new Exception("Incorrect password");

            return await CreateTokenAsync(userExist);
        } catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<string> CreateTokenAsync(User user)
    {
        List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.Name),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}
