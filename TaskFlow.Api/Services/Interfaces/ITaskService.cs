using TaskFlow.Api.DTOs.Tasks;

namespace TaskFlow.Api.Services.Interfaces;

public interface ITaskService
{
    Task<List<TaskItemDto>> GetByProjectIdAsync(int projectId);
    Task<TaskItemDto?> CreateAsync(int projectId, CreateTaskDto dto);
    Task<bool> UpdateAsync(int id, UpdateTaskDto dto);
    Task<bool> DeleteAsync(int id);
}