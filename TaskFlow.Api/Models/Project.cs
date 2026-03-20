namespace TaskFlow.Api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public List<TaskItem> Tasks { get; set; } = new();
    }
}
