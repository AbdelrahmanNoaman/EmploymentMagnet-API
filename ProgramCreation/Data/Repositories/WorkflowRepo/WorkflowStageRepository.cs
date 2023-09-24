using ProgramCreation.DTOs;
using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Data.Repositories;

namespace ProgramCreation.Data.Repositories
{
    public class WorkflowStageRepository
    {
        private StagesRepository _stageRepo = new();
        private WorkflowRepository _workflowRepo = new();
        private StagesTypeRepository _stagesTypeRepo = new();

        public async Task<WorkflowDTO> GetFullInformation(string workflowId)
        {
            Workflow workflow = await _workflowRepo.GetById(workflowId);

            List<StageDTO> stages = new List<StageDTO>();

            foreach (StageInfoDTO stageInfo in workflow.Stages)
            {
                StageDTO stage = await _stageRepo.GetById(stageInfo);
                stages.Add(stage);
            }
            List<StageType> types = await _stagesTypeRepo.GetAllTypes();
            return new WorkflowDTO(workflow.id, stages, types);
        }

    }
}
