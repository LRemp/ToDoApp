using Core.Entities;

namespace Core.DTOs;

public class TaskItemDTO
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    public Priority Priority { get; set; }
}