using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Models.DTOs;
using server.Services.Interfaces;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors("AuthenticationPolicy")]
public class UserAuthController : ControllerBase
{
    private readonly IUserService _userService;

    public UserAuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<ActionResult<string>> Login(UserAuthInfoDto request)
    {
        if (request == null) return BadRequest("User authentication info does not exist in request.");
        var response = await _userService.AuthenticateUser(request);
        if (response.GetType() != typeof(string)) return BadRequest(response);
        return Ok(response);
    }
}
