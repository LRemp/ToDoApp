using Core.Contracts;
using Core.DTOs;
using Core.Entities;
using Dapper;
using MySqlConnector;

namespace Repositories.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly MySqlConnection _mysqlConnection;
    public TaskRepository(MySqlConnection mysqlConnection)
    {
        _mysqlConnection = mysqlConnection;
        _mysqlConnection.Open();
    }
    public async Task<List<TaskItem>> GetTasks()
    {
        var query = @"SELECT * FROM tasks";
        var tasks = await _mysqlConnection.QueryAsync<TaskItem>(query);
        return tasks.ToList();
    }
    public async Task<List<TaskItem>> GetTasks(int ownerId)
    {
        var query = @"SELECT * FROM tasks WHERE owner = @owner";
        var tasks = await _mysqlConnection.QueryAsync<TaskItem>(query, new { owner = ownerId });
        return tasks.ToList();
    }

    public async Task<TaskItem> GetTask(int id)
    {
        var query = @"SELECT * FROM tasks WHERE id = @id";
        var tasks = await _mysqlConnection.QueryAsync<TaskItem>(query, new { id });
        return tasks.FirstOrDefault();
    }

    public async Task AddTask(TaskItemDTO taskItem, User user)
    {
        var query = @"INSERT INTO tasks (title, owner, description, deadline, priority)
                      VALUES (@title, @owner, @description, @deadline, @priority)";

        await _mysqlConnection.QueryAsync(query, new
        {
            title = taskItem.Title,
            owner = user.Id,
            description = taskItem.Description,
            deadline = taskItem.Deadline,
            priority = taskItem.Priority
        });
    }

    public Task UpdateTask(int taskId, TaskItemDTO taskItem)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteTask(int id)
    {
        var query = @"DELETE FROM tasks WHERE id = @id";

        await _mysqlConnection.QueryAsync(query, new { id });
    }
}