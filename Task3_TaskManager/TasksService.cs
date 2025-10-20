using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace Task3_TaskManager
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _repository;
        public TasksService(ITasksRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<TaskItem> SelectAllTasks() {
            return _repository.GetAllTasks();
        }
        public void CreateNewTask(TaskItem task)
        {
            task.CreatedAt = DateTime.Now;
            _repository.AddTask(task);
        }
        public void UpdateTask(int taskId)
        {
            _repository.UpdateTask(taskId);
        }
        public void DeleteTask(int taskId)
        {
            _repository.DeleteTask(taskId);
        }
    }
}
