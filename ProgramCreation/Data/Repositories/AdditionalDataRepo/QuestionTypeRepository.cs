using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;

namespace ProgramCreation.Data.Repositories.AdditionalDataRepo
{
    public class QuestionTypeRepository
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("questiontypes");

        public async Task<List<QuestionTypes>> GetAllTypes()
        {
            return await AdditionalDataRepository<QuestionTypes>.GetAllTypes(_container);
        }

        public async Task Add(QuestionTypes stageType)
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
