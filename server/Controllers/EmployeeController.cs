using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models.In;
using server.Models.Out;
using server.Services.Interfaces;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase {

    private readonly IUserService _userService;

    public EmployeeController(IUserService userService) {
        _userService = userService;
    }

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<ActionResult<EmployeeOut>> Register(EmployeeIn employeeIn) {
        try {
            if (ModelState.IsValid) {
                var response = await _userService.RegisterAnEmployee(employeeIn);
                return response;
            } else return BadRequest(ModelState);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}