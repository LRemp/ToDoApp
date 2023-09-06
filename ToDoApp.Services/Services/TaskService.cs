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
    public async Task<List<TaskItem>> GetAsync(int ownerId)
    {
        List<TaskItem> tasks = await _taskRepository.GetTasks(ownerId);
        return tasks;
    }

    public async Task<TaskItem> GetSingleAsync(int id)
    {
        TaskItem task = await _taskRepository.GetTask(id);
        return task;
    }
    public async Task AddAsync(TaskItemDTO taskItem, User user)
    {
        await _taskRepository.AddTask(taskItem, user);
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