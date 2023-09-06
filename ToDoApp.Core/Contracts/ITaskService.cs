using Core.DTOs;
using Core.Entities;

namespace Core.Contracts;

public interface ITaskService
{
    public Task<List<TaskItem>> GetAsync(int ownerId);
    public Task<TaskItem> GetSingleAsync(int id);
    public Task AddAsync(TaskItemDTO taskItem, User user);
    public Task<bool> UpdateAsync(int id, TaskItemDTO taskItem);
    public Task<bool> DeleteAsync(int id);
}