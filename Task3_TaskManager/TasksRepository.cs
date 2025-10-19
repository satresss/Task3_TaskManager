using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Task3_TaskManager
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IDbConnection _connection;

        public TasksRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return _connection.Query<   >("SELECT * FROM Tasks");
        }

        public void AddTask(TaskItem task)
        {
            string sql = "INSERT INTO Tasks (Title, Description, IsCompleted, CreatedAt) VALUES (@Title, @Description, @IsCompleted, @CreatedAt)";
            _connection.Execute(sql, task);
        }

        public void UpdateTask(TaskItem task)
        {
            string sql = @"UPDATE Tasks 
                       SET Title = @Title, Description = @Description, IsCompleted = @IsCompleted 
                       WHERE Id = @Id";
            _connection.Execute(sql, task);
        }

        public void DeleteTask(int taskId)
        {
            string sql = "DELETE FROM Tasks WHERE Id = @Id";
            _connection.Execute(sql, new { Id = taskId });
        }

    }
}
