using ProgramCreation.DTOs;
using ProgramCreation.Interfaces;
using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;

namespace ProgramCreation.Data.Repositories
{
    public class ProgramRepository : IRepository<FullProgram, string>
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("forms");

        public async Task<FullProgram> GetById(string programId)
        {
            var result = await _container.ReadItemAsync<FullProgram>(programId, new PartitionKey(programId));
            return result.Resource;
        }

        public async Task<String> Add(FullProgram program)
        {
            program.id = Guid.NewGuid().ToString();
            await _container.CreateItemAsync(program);
            return program.id;
        }

        public async Task Delete(string formId)
        {
            var result = await _container.DeleteItemAsync<Object>(formId, new PartitionKey(formId));
        }
    }
}
