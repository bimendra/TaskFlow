using TaskFlow.Api.DTOs.Tasks;
using TaskFlow.Api.Models;
using TaskFlow.Api.Repositories.Interfaces;
using TaskFlow.Api.Services.Interfaces;

namespace TaskFlow.Api.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public TaskService(ITaskRepository taskRepository, IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<List<TaskItemDto>> GetByProjectIdAsync(int projectId)
    {
        var tasks = await _taskRepository.GetByProjectIdAsync(projectId);
        return tasks.Select(MapToDto).ToList();
    }

    public async Task<TaskItemDto?> CreateAsync(int projectId, CreateTaskDto dto)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);
        if (project is null) return null;

        var task = new TaskItem
        {
            ProjectId = projectId,
            Title = dto.Title,
            Description = dto.Description,
            Status = dto.Status,
            Priority = dto.Priority,
            AssignedTo = dto.AssignedTo,
            DueDateUtc = dto.DueDateUtc,
            CreatedAtUtc = DateTime.UtcNow
        };

        var created = await _taskRepository.AddAsync(task);
        return MapToDto(created);
    }

    public async Task<bool> UpdateAsync(int id, UpdateTaskDto dto)
    {
        var existing = await _taskRepository.GetByIdAsync(id);
        if (existing is null) return false;

        existing.Title = dto.Title;
        existing.Description = dto.Description;
        existing.Status = dto.Status;
        existing.Priority = dto.Priority;
        existing.AssignedTo = dto.AssignedTo;
        existing.DueDateUtc = dto.DueDateUtc;

        await _taskRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _taskRepository.GetByIdAsync(id);
        if (existing is null) return false;

        await _taskRepository.DeleteAsync(existing);
        return true;
    }

    private static TaskItemDto MapToDto(TaskItem task)
    {
        return new TaskItemDto
        {
            Id = task.Id,
            ProjectId = task.ProjectId,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            Priority = task.Priority,
            AssignedTo = task.AssignedTo,
            DueDateUtc = task.DueDateUtc,
            CreatedAtUtc = task.CreatedAtUtc
        };
    }
}