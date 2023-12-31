﻿using ProgramCreation.DTOs;
using ProgramCreation.Interfaces;
using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;
using ProgramCreation.Models;
using ProgramCreation.Validations;

namespace ProgramCreation.Data.Repositories
{
    public class WorkflowRepository : IRepository<Workflow, string>
    {
        private Container _container = new DbContext().GetContainer("workflow");

        public async Task<Workflow> GetById(string WorkflowId)
        {
            var result = await _container.ReadItemAsync<Workflow>(WorkflowId, new PartitionKey(WorkflowId));
            WorkflowValidation.IsworkflowExist(result.Resource);
            return result.Resource;
        }

        public async Task<string> Add(Workflow workflow)
        {
            workflow.id = Guid.NewGuid().ToString();
            var result = await _container.CreateItemAsync(workflow);
            return workflow.id;
        }

        public async Task Delete(string workflowId)
        {
            await this.GetById(workflowId);
            var result = await _container.DeleteItemAsync<object>(workflowId, new PartitionKey(workflowId));
        }

        public async Task AddStage(string workflowId, StageInfoDTO stageInfo)
        {
            Workflow workflow = await GetById(workflowId);
            await WorkflowValidation.CheckForStageAdd(workflow, stageInfo);
            workflow.Stages.Add(stageInfo);
            await _container.ReplaceItemAsync<Workflow>(workflow, workflowId, new PartitionKey(workflowId));
        }

        public async Task DeleteStage(string workflowId, StageInfoDTO stageInfo)
        {
            Workflow workflow = await GetById(workflowId);
            await WorkflowValidation.CheckForStageRemove(workflow, stageInfo);
            workflow.Stages.RemoveAll(info => info.id == stageInfo.id && info.Type == stageInfo.Type);
            await _container.ReplaceItemAsync<Workflow>(workflow, workflowId, new PartitionKey(workflowId));
        }
    }
}
