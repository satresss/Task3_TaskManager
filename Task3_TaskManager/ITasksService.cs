using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_TaskManager
{
    public interface ITasksService
    {
        public static void SelectAllTasks() { }
        public static void CreateNewTask() { }
        public static void UpdateTask() { }
        public static void DeleteTask() { }
    }
}
