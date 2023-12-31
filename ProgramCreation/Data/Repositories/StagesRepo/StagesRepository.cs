﻿using ProgramCreation.DTOs;
using ProgramCreation.Interfaces;
using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;
using ProgramCreation.Validations;

namespace ProgramCreation.Data.Repositories
{
    public class StagesRepository : IRepository<StageDTO, StageInfoDTO>
    {
        private Container _container = new DbContext().GetContainer("stages");

        public async Task<StageDTO> GetById(StageInfoDTO StageInfo)
        {
            var result = await _container.ReadItemAsync<StageDTO>(StageInfo.id, new PartitionKey(StageInfo.Type));
            StageValidation.isStageExists(result.Resource);
            return result.Resource;
        }

        public async Task<StageInfoDTO> Add(StageDTO stage)
        {
            stage.id = Guid.NewGuid().ToString();
            await StageValidation.Validate(stage);
            var result = await _container.CreateItemAsync(stage);
            return new StageInfoDTO { id = stage.id, Type = stage.Type };
        }

        public async Task Delete(StageInfoDTO stageInfo)
        {
            await this.GetById(stageInfo);
            await _container.DeleteItemAsync<object>(stageInfo.id, new PartitionKey(stageInfo.Type));
        }
    }
}