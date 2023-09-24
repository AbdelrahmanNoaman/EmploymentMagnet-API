using ProgramCreation.Interfaces;
using Microsoft.Azure.Cosmos;
using ProgramCreation.Models;

namespace ProgramCreation.Data.Repositories
{
    public class ProgramInfoRepository : IRepository<ProgramInfo, string>
    {
        private Container _container = new DbContext().GetContainer("programinfo");


        public async Task<ProgramInfo> GetById(string programInfoId)
        {
            var result = await _container.ReadItemAsync<ProgramInfo>(programInfoId, new PartitionKey(programInfoId));
            return result.Resource;
        }

        public async Task<string> Add(ProgramInfo programInfo)
        {
            programInfo.id = Guid.NewGuid().ToString();
            var result = await _container.CreateItemAsync(programInfo);
            return programInfo.id;
        }

        public async Task Delete(string programId)
        {
            var result = await _container.DeleteItemAsync<object>(programId, new PartitionKey(programId));
        }

        public async Task<ProgramInfo> Update(ProgramInfo programInfo)
        {
            ProgramInfo result = await _container.ReadItemAsync<ProgramInfo>(programInfo.id, new PartitionKey(programInfo.id));
            result = programInfo;
            var finalResult = await _container.ReplaceItemAsync<ProgramInfo>(programInfo, programInfo.id, new PartitionKey(programInfo.id));
            return finalResult.Resource;
        }
    }
}
