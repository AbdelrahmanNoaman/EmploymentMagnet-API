using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Data
{
    internal class DbContext
    {
        private string _connectionString;
        private CosmosClient _client;
        private Database _database;

        public DbContext()
        {
            IConfiguration configuration = SetupConfiguration.Setup();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:Database");
            _client = new CosmosClient(_connectionString);
            _database = _client.GetDatabase(configuration.GetValue<string>("DatabaseInfo:databaseName"));
        }
        public Container GetContainer(string ContainerName)
        {
            return this._database.GetContainer(ContainerName);
        }
    }
}
