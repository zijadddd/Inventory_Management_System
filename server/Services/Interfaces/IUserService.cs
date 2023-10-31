using server.Models.In;

namespace server.Services.Interfaces;
public interface IUserService {
    Task<dynamic> RegisterAnEmployee(EmployeeIn employeeIn);
    Task<string> AuthenticateUser(UserAuthInfoIn userAuthInfoDto);
}
