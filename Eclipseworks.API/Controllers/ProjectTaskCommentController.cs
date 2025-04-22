using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Eclipseworks.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskCommentController : ControllerBase
    {
        private readonly IProjectTaskCommentService _projectTaskCommentService;
        public ProjectTaskCommentController(IProjectTaskCommentService projectTaskCommentService)
        {
            _projectTaskCommentService = projectTaskCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _projectTaskCommentService.GetProjectTaskComments();
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _projectTaskCommentService.Get(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        [Route("GetByProjectTask/{projectTaskId:int}")]
        public async Task<IActionResult> GetByProjectTask(int projectTaskId)
        {
            var result = await _projectTaskCommentService.GetByProjectTask(projectTaskId);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectTaskCommentDTO projectTaskCommentDTO)
        {
            var result = await _projectTaskCommentService.Create(projectTaskCommentDTO);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProjectTaskCommentDTO projectTaskCommentDTO)
        {
            var result = await _projectTaskCommentService.Update(projectTaskCommentDTO);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectTaskCommentService.Remove(id);
            return StatusCode(result.StatusCode, result);
        }

    }
}
