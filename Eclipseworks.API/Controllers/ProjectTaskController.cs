﻿using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Eclipseworks.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;
        public ProjectTaskController(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _projectTaskService.GetProjectTasks();
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _projectTaskService.Get(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _projectTaskService.Get(name);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("{id:int}/{projectId:int}")]
        public async Task<IActionResult> Get(int id, int projectId)
        {
            var result = await _projectTaskService.Get(id, projectId);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        [Route("GetByProject/{projectId:int}")]
        public async Task<IActionResult> GetByProject(int projectId)
        {
            var result = await _projectTaskService.GetByProject(projectId);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectTaskDTO projectTaskDTO)
        {
            var result = await _projectTaskService.Create(projectTaskDTO);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProjectTaskDTO projectTaskDTO)
        {
            var result = await _projectTaskService.Update(projectTaskDTO);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        [Route("TaskStart/{id:int}")]
        public async Task<IActionResult> TaskStart(int id)
        {
            var result = await _projectTaskService.TaskStart(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        [Route("TaskFinished/{id:int}")]
        public async Task<IActionResult> TaskFinished(int id)
        {
            var result = await _projectTaskService.TaskFinished(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectTaskService.Remove(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
