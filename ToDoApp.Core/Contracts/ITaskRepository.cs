using Core.DTOs;
using Core.Entities;

namespace Core.Contracts;

public interface ITaskRepository
{
    public Task<List<TaskItem>> GetTasks();
    public Task<List<TaskItem>> GetTasks(int ownerId);
    public Task AddTask(TaskItemDTO taskItem);
    public Task UpdateTask(int taskId, TaskItemDTO taskItem);
    public Task DeleteTask(int id);
}