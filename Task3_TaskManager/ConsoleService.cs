using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task3_TaskManager
{
    public class ConsoleService : IConsoleService
    {
        private readonly ITasksService _tasksService;

        public ConsoleService(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        public void CommandEnter()
        {
            while (true)
            {
                ShowMenu();
                int choice = ReadChoice();

                if (!ExecuteChoice(choice))
                    break;
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Просмотр всех задач");
            Console.WriteLine("2 - Добавление новой задачи");
            Console.WriteLine("3 - Обновить задачу");
            Console.WriteLine("4 - Удаление задачи");
            Console.WriteLine("5 - Выход");
        }

        private int ReadChoice()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                    return choice;

                Console.WriteLine("Ошибка ввода, введите число от 1 до 5.");
            }
        }

        private bool ExecuteChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    var tasks = _tasksService.SelectAllTasks();
                    foreach (var t in tasks)
                    {
                        Console.WriteLine($"Id.{t.Id} {t.Title} - {(t.IsCompleted ? "Выполнено" : "Не выполнено")} ({t.CreatedAt}\n{t.Description}");
                    }
                    break;

                case 2:
                    var newTask = new TaskItem
                    {
                        Title = ReadString("Введите заголовок задачи: "),
                        Description = ReadString("Введите описание задачи: "),
                        IsCompleted = false
                    };
                    _tasksService.CreateNewTask(newTask);
                    Console.WriteLine("Задача добавлена.");
                    break;

                case 3:
                    int updateId = ReadInt("Введите Id задачи для обновления: ");
                    _tasksService.UpdateTask(updateId);
                    Console.WriteLine("Задача обновлена.");
                    break;

                case 4:
                    int deleteId = ReadInt("Введите Id задачи для удаления: ");
                    _tasksService.DeleteTask(deleteId);
                    Console.WriteLine("Задача удалена.");
                    break;

                case 5:
                    Console.WriteLine("Выход из программы...");
                    return false;

                default:
                    Console.WriteLine("Ошибка выбора, попробуйте ещё раз");
                    break;
            }
            return true;
        }
        private string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }

        private int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Ошибка ввода, введите число.");
            }
        }

    }
}

