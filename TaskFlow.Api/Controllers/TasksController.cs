using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs.Tasks;
using TaskFlow.Api.Services.Interfaces;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("projects/{projectId:int}/tasks")]
    public async Task<ActionResult<List<TaskItemDto>>> GetByProjectId(int projectId)
    {
        var tasks = await _taskService.GetByProjectIdAsync(projectId);
        return Ok(tasks);
    }

    [HttpPost("projects/{projectId:int}/tasks")]
    public async Task<ActionResult<TaskItemDto>> Create(int projectId, CreateTaskDto dto)
    {
        var created = await _taskService.CreateAsync(projectId, dto);
        if (created is null) return NotFound("Project not found.");

        return Ok(created);
    }

    [HttpPut("tasks/{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
    {
        var updated = await _taskService.UpdateAsync(id, dto);
        if (!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete("tasks/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _taskService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}