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
        public void SelectAllTasks() {
            return _repository.GetAllTasks();
        }
        public void CreateNewTask(Task task)
        {
            task.CreatedAt = DateTime.Now;
            _repository.AddTask(TaskItem);
        }
        public void UpdateTask(Task task)
        {
            _repository.UpdateTask(TaskItem);
        }
        public void DeleteTask(int taskId)
        {
            _repository.DeleteTask(taskId);
        }
    }
}
