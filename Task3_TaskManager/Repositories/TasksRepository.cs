using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Task3_TaskManager.Interfaces;
using Task3_TaskManager.Models;

namespace Task3_TaskManager.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IDbConnection _connection;

        public TasksRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            const string sql = "SELECT * FROM Tasks";
            return await _connection.QueryAsync<TaskItem>(sql);
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            const string sql = "INSERT INTO Tasks (Title, Description, IsCompleted, CreatedAt) VALUES (@Title, @Description, @IsCompleted, @CreatedAt)";
            await _connection.ExecuteAsync(sql, task);
        }

        public async Task UpdateTaskAsync(int taskId)
        {
            const string sql = @"
                UPDATE Tasks 
                SET IsCompleted = CASE WHEN IsCompleted = 1 THEN 0 ELSE 1 END
                WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = taskId });
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            const string sql = "DELETE FROM Tasks WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = taskId });
        }
    }
}
