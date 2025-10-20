using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Task3_TaskManager.Interfaces;
using Task3_TaskManager.Services;
using Task3_TaskManager.Repositories;

var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();

string connectionString = builder.GetConnectionString("DefaultConnection");

var services = new ServiceCollection();

services.AddTransient<IDbConnection>(_ => new SqlConnection(connectionString));
services.AddTransient<ITasksRepository, TasksRepository>();
services.AddTransient<ITasksService, TasksService>();
services.AddTransient<IConsoleService, ConsoleService>();

var provider = services.BuildServiceProvider();

var consoleService = provider.GetRequiredService<IConsoleService>();

await consoleService.CommandEnterAsync();
