using Core.DTOs;
using Core.Entities;

namespace Core.Contracts;

public interface ITaskService
{
    public Task<List<TaskItem>> GetAsync();
    public Task<TaskItem> GetAsync(int id);
    public Task AddAsync(TaskItemDTO taskItem);
    public Task<bool> UpdateAsync(int id, TaskItemDTO taskItem);
    public Task<bool> DeleteAsync(int id);
}