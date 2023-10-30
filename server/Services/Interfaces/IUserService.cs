using server.Models.DTOs;
using server.Models.In;
using server.Models.Out;

namespace server.Services.Interfaces;
public interface IUserService {
    Task<dynamic> RegisterAnEmployee(EmployeeIn employeeIn);
    Task<dynamic> AuthenticateUser(UserAuthInfoDto userAuthInfoDto);
}
