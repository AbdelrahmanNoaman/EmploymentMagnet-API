using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;
using ProgramCreation.Data.Repositories.AdditionalDataRepo;

namespace ProgramCreation.Data.Repositories
{
    public class StagesTypeRepository 
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("stagestypes");

        public async Task<List<StageType>> GetAllTypes()
        {
            return await AdditionalDataRepository<StageType>.GetAllTypes(_container);
        }

        public async Task Add(StageType stageType)
        {
            stageType.id = Guid.NewGuid().ToString();
            var result = await _container.CreateItemAsync(stageType);
        }

        public async Task Delete(StageType stageType)
        {
            await _container.DeleteItemAsync<Object>(stageType.id, new PartitionKey(stageType.id));
        }
    }
}
