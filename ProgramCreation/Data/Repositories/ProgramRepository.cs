using ProgramCreation.DTOs;
using ProgramCreation.Interfaces;
using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;
using ProgramCreation.Models.Questions;

namespace ProgramCreation.Data.Repositories
{
    public class ProgramRepository : IRepository<FullProgram, string>
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("programs");

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

        public async Task AddProgramInfo(string programIfnoId, string programId)
        {
            FullProgram prog = await this.GetById(programId);
            prog.ProgramInfoId = programIfnoId;
            await _container.ReplaceItemAsync<FullProgram>(prog, prog.id, new PartitionKey(prog.id));
        }
    }
}
