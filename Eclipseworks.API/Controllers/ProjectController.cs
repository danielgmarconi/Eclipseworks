using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Eclipseworks.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _projectService.GetProjects();
        return StatusCode(result.StatusCode, result);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _projectService.GetById(id);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProjectDTO projectDTO)
    {
        var result = await _projectService.Create(projectDTO);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProjectDTO projectDTO)
    {
        var result = await _projectService.Update(projectDTO);
        return StatusCode(result.StatusCode, result);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _projectService.Remove(id);
        return StatusCode(result.StatusCode, result);
    }
}
