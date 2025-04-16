using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _userService.GetUsers();
        return StatusCode(result.StatusCode, result);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _userService.GetById(id);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDTO userDto)
    {
        var result = await _userService.Create(userDto);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UserDTO userDto)
    {
        var result = await _userService.Update(userDto);
        return StatusCode(result.StatusCode, result);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userService.Remove(id);
        return StatusCode(result.StatusCode, result);
    }
}
