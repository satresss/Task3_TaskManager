using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task3_TaskManager
{
    public class ConsoleService
    {
        private readonly ITasksService _tasksService;
        public ConsoleService(ITasksService tasksService) { 
            _tasksService = tasksService; 
        }
        public static void CommandEnter() {
            while (true) {
                Console.WriteLine("Выберите действие \n1-Просмотр всех задач\n2-Добавление новой задачи\n3-Обновить задачу\n4-Удаление задачи");
                bool result = int.TryParse(Console.ReadLine(), out int choise);
                if (!result) {
                    Console.WriteLine("Ошибка ввода, попробуйте ещё раз");
                    continue;
                }
                switch (choise) {
                    case 1: { TasksService.SelectAllTasks(); break; }
                    case 2: { continue; break; }
                    case 3: { continue; break; }
                    case 4: { continue; break; }
                    default: { Console.WriteLine("Ошибка выбора, попробуйте ещё раз"); break; }
                }
            }
        }


    }
}
