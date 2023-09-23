using ProgramCreation.DTOs;
using ProgramCreation.Interfaces;
using ProgramCreation.Models.Stages.Base_Stages;
using Microsoft.Azure.Cosmos;
namespace ProgramCreation.Data.Repositories
{
    public class StagesRepository:IRepository<StageDTO,StageInfoDTO>
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("stages");

        public async Task<StageDTO> GetById(StageInfoDTO StageInfo)
        {
            var result = await _container.ReadItemAsync<StageDTO>(StageInfo.id, new PartitionKey(StageInfo.Type));
            return result.Resource;
        }

        public async Task<StageInfoDTO> Add(StageDTO stage)
        {
            stage.id = Guid.NewGuid().ToString();
            var result = await _container.CreateItemAsync(stage);
            return new StageInfoDTO { id = stage.id, Type = stage.Type };
        }

        public async Task Delete(StageInfoDTO questionInfo)
        {
           await _container.DeleteItemAsync<Object>(questionInfo.id, new PartitionKey(questionInfo.Type));
        }
    }
}