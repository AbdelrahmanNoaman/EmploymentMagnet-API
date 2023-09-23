using ProgramCreation.DTOs;
using ProgramCreation.Interfaces;
using ProgramCreation.Models.Forms;
using Microsoft.Azure.Cosmos;
using ProgramCreation.Models.Workflow;

namespace ProgramCreation.Data.Repositories
{
    public class WorkflowRepository : IRepository<Workflow, string>
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("workflow");

        public async Task<Workflow> GetById(string WorkflowId)
        {
            var result = await _container.ReadItemAsync<Workflow>(WorkflowId, new PartitionKey(WorkflowId));
            return result.Resource;
        }

        public async Task<String> Add(Workflow workflow)
        {
            workflow.id = Guid.NewGuid().ToString();
            workflow.Stages = new List<StageInfoDTO>();
            var result = await _container.CreateItemAsync(workflow);
            return workflow.id;
        }

        public async Task Delete(string workflowId)
        {
            var result = await _container.DeleteItemAsync<Object>(workflowId, new PartitionKey(workflowId));
        }

        public async Task AddStage(string workflowId, StageInfoDTO stageInfo)
        {
            Workflow workflow = await this.GetById(workflowId);
            workflow.Stages.Add(stageInfo);
            await _container.ReplaceItemAsync<Workflow>(workflow, workflowId, new PartitionKey(workflowId));
        }

        public async Task DeleteStage(string workflowId, StageInfoDTO stageInfo)
        {
            Workflow workflow = await this.GetById(workflowId);
            workflow.Stages.Remove(stageInfo);
            await _container.ReplaceItemAsync<Workflow>(workflow, workflowId, new PartitionKey(workflowId));
        }
    }
}
