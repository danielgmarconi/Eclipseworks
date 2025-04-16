using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthorizationController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    [Route("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] UserDTO userDto)
    {
        var result = await _userService.Create(userDto);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPost]
    [Route("Authentication")]
    [AllowAnonymous]
    public async Task<IActionResult> Authentication([FromBody] AuthenticationDTO authenticationDTO)
    {
        var result = await _userService.Authentication(authenticationDTO);
        return StatusCode(result.StatusCode, result);
    }    
}
