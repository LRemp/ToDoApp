using Core.Contracts;
using Core.DTOs;
using Core.Entities;

namespace Services.Services;

public class TaskService: ITaskService
{
    private readonly ITaskRepository _taskRepository;
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<List<TaskItem>> GetAsync()
    {
        List<TaskItem> tasks = await _taskRepository.GetTasks();
        return tasks;
    }

    public Task<TaskItem> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(TaskItemDTO taskItem)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(int id, TaskItemDTO taskItem)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}