using TaskFlow.Api.Models;

namespace TaskFlow.Api.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetByProjectIdAsync(int projectId);
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(TaskItem task);
}