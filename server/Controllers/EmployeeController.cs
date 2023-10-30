using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models.In;
using server.Models.Out;
using server.Services.Interfaces;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase {

    private readonly IUserService _userService;

    public EmployeeController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("RegisterAnEmployee"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<EmployeeOut>> Register(EmployeeIn employeeIn) {
        try
        {
            if (ModelState.IsValid)
            {
                DateTime minDate = new DateTime(2020, 1, 1);
                DateTime maxDate = DateTime.Today;

                if (!DateTime.TryParse(employeeIn.DateOfEmployment, out DateTime inputDate))
                    return BadRequest("Invalid date format for date of employment.");

                if (!(inputDate >= minDate && inputDate <= maxDate))
                    return BadRequest("Invalid date format for date of employment.");

                var response = await _userService.RegisterAnEmployee(employeeIn);

                return response;
            }
            else return BadRequest(ModelState);
        } catch (Exception ex)
        {
            return BadRequest("Something is not good.");
        }
    }
}