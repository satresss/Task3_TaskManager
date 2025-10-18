using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Task3_TaskManager
{
    public class TasksRepository
    {
        private readonly IDbConnection _connection;
        public TasksRepository(IDbConnection connection) {
            _connection = connection;
        }
        public IEnumerable<Tasks> GetALL() => _connection.Query<Tasks>("Select");
        
    }
}
