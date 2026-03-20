namespace TaskFlow.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = "Todo";
        public string Priority { get; set; } = "Medium";
        public string? AssignedTo { get; set; }
        public DateTime? DueDateUtc { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public Project? Project { get; set; }
    }
}
