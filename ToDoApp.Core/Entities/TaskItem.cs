namespace Core.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public int Owner { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    public Priority Priority { get; set; }
}