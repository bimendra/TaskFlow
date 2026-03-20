using TaskFlow.Api.DTOs.Projects;
using TaskFlow.Api.Models;
using TaskFlow.Api.Repositories.Interfaces;
using TaskFlow.Api.Services.Interfaces;

namespace TaskFlow.Api.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<ProjectDto>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllAsync();

        return projects.Select(MapToDto).ToList();
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        return project is null ? null : MapToDto(project);
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
    {
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description,
            Status = dto.Status,
            CreatedAtUtc = DateTime.UtcNow
        };

        var created = await _projectRepository.AddAsync(project);
        return MapToDto(created);
    }

    public async Task<bool> UpdateAsync(int id, UpdateProjectDto dto)
    {
        var existing = await _projectRepository.GetByIdAsync(id);
        if (existing is null) return false;

        existing.Name = dto.Name;
        existing.Description = dto.Description;
        existing.Status = dto.Status;

        await _projectRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _projectRepository.GetByIdAsync(id);
        if (existing is null) return false;

        await _projectRepository.DeleteAsync(existing);
        return true;
    }

    private static ProjectDto MapToDto(Project project)
    {
        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            Status = project.Status,
            CreatedAtUtc = project.CreatedAtUtc
        };
    }
}