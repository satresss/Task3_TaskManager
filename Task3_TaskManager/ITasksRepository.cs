using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_TaskManager
{
    public interface ITasksRepository
    {
        IEnumerable<Task> GetAll();
        Task? GetById(int id);
        void Add(Task task);
        void Update(Task task);
        void Delete(int id);
    }
}
