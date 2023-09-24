using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;

namespace ProgramCreation.Data.Repositories.AdditionalDataRepo
{
    public class ProgramTypeRepository
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("programtypes");

        public async Task<List<ProgramType>> GetAllTypes()
        {
            return await AdditionalDataRepository<ProgramType>.GetAllTypes(_container);
        }

        public async Task Add(ProgramType programType)
        {
            programType.id = Guid.NewGuid().ToString();
            var result = await _container.CreateItemAsync(programType);
        }

        public async Task Delete(StageType stageType)
        {
            await _container.DeleteItemAsync<Object>(stageType.id, new PartitionKey(stageType.id));
        }
    }
}
