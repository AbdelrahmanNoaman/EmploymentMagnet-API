using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;

namespace ProgramCreation.Data.Repositories
{
    public class StagesTypeRepository 
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("stagestypes");

        public async Task<List<StageType>> GetAllTypes()
        {
            var result =  _container.GetItemQueryIterator<StageType>("SELECT * FROM c");
            List<StageType> types = new List<StageType>();
            while (result.HasMoreResults)
            {
                var response = await result.ReadNextAsync();
                foreach (var item in response)
                {
                    types.Add(item);
                }
            }
            return types;
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
