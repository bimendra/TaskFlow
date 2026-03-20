namespace TaskFlow.Api.DTOs.Tasks;

public class TaskItemDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string? AssignedTo { get; set; }
    public DateTime? DueDateUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}