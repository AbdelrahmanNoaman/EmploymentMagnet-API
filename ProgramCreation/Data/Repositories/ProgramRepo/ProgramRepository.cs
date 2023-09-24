using ProgramCreation.Interfaces;
using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;

namespace ProgramCreation.Data.Repositories
{
    public class ProgramRepository : IRepository<FullProgram, string>
    {
        private Container _container = new DbContext().GetContainer("programs");

        public async Task<FullProgram> GetById(string programId)
        {
            var result = await _container.ReadItemAsync<FullProgram>(programId, new PartitionKey(programId));
            return result.Resource;
        }

        public async Task<string> Add(FullProgram program)
        {
            program.id = Guid.NewGuid().ToString();
            await _container.CreateItemAsync(program);
            return program.id;
        }

        public async Task Delete(string formId)
        {
            var result = await _container.DeleteItemAsync<object>(formId, new PartitionKey(formId));
        }

        public async Task AddProgramInfo(string programIfnoId, string programId)
        {
            FullProgram prog = await GetById(programId);
            prog.ProgramInfoId = programIfnoId;
            await _container.ReplaceItemAsync(prog, prog.id, new PartitionKey(prog.id));
        }
    }
}
