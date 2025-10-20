using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task3_TaskManager.Interfaces;
using Task3_TaskManager.Models;

namespace Task3_TaskManager.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _repository;

        public TasksService(ITasksRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> SelectAllTasksAsync()
        {
            return await _repository.GetAllTasksAsync();
        }

        public async Task CreateNewTaskAsync(TaskItem task)
        {
            task.CreatedAt = DateTime.Now;
            await _repository.AddTaskAsync(task);
        }

        public async Task UpdateTaskAsync(int taskId)
        {
            await _repository.UpdateTaskAsync(taskId);
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            await _repository.DeleteTaskAsync(taskId);
        }
    }
}
