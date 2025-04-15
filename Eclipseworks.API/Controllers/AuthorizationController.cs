using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    public readonly IUserService _userService;
    public AuthorizationController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    [AllowAnonymous]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserDTO userDto)
    {
        if (userDto == null)
            return BadRequest("Invalid Data");
        await _userService.Create(userDto);
        return new CreatedAtRouteResult("GetUser", new { id = userDto.Id }, userDto);
    }
}
