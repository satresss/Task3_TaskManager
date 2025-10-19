using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_TaskManager
{
    public interface ITasksRepository
    {
        IEnumerable<TaskItem> GetAllTasks();
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int taskId);
    }
}
