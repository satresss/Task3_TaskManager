using System.Collections.Generic;
using System.Threading.Tasks;
using Task3_TaskManager.Models;

namespace Task3_TaskManager.Interfaces
{
    public interface ITasksService
    {
        Task<IEnumerable<TaskItem>> SelectAllTasksAsync();
        Task CreateNewTaskAsync(TaskItem task);
        Task UpdateTaskAsync(int taskId);
        Task DeleteTaskAsync(int taskId);
    }
}
