using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.Helpers.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming005.WebProj.Helpers
{
    public class DatabaseLoghelper : IDatabaseLogHelper
    {
        private readonly IDatabase _database;

        public DatabaseLoghelper(IDatabase database)
        {
            _database = database;
        }

        public void AddOpertionLog(string operation)
        {
            operation = operation.Trim();

            _database.AddOperation(operation);
        }
    }
}
