using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_TaskManager.Models;

namespace Task3_TaskManager.Interfaces
{
    public interface ITasksRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task AddTaskAsync(TaskItem task);
        Task UpdateTaskAsync(int taskId);
        Task DeleteTaskAsync(int taskId);
    }
}
