using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.DTOs.Tasks;

public class UpdateTaskDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = "Todo";

    [Required]
    [MaxLength(50)]
    public string Priority { get; set; } = "Medium";

    [MaxLength(100)]
    public string? AssignedTo { get; set; }

    public DateTime? DueDateUtc { get; set; }
}