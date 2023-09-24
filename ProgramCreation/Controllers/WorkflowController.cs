using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Data.Repositories;
using ProgramCreation.DTOs;
using ProgramCreation.Models;

namespace ProgramCreation.Controllers
{
    [ApiController]
    public class WorkflowController : Controller
    {
        private StagesRepository _stageRepo = new();
        private WorkflowRepository _workflowRepo = new();
        private StagesTypeRepository _stagesTypeRepo = new();

        private WorkflowStageRepository _workflowStageRepo = new();

        [Route("api/workflow/")]
        [HttpGet]
        public async Task<ResponseDTO<WorkflowDTO>> GetWorkflow(WorkflowStageDTO workflowStages)
        {
            try
            {
                WorkflowDTO ResultantWorkflow = await _workflowStageRepo.GetFullInformation(workflowStages.workflowId);
                ResponseDTO<WorkflowDTO> response = new(200, "Workflow Has Been Returned Successfully", ResultantWorkflow);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<WorkflowDTO> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/workflow/addStage")]
        [HttpPut]
        public async Task<ResponseDTO<StageInfoDTO>> AddStage(WorkflowStageDTO stage)
        {
            try
            {
                StageInfoDTO stageInfo = await _stageRepo.Add(stage.Stage);
                await _workflowRepo.AddStage(stage.workflowId, stageInfo);
                ResponseDTO<StageInfoDTO> response = new(200, "Stage Has Been Added Successfully", stageInfo);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<StageInfoDTO> response = new(500, "Internal Server Error", null);
                return response;
            }
        }


        [Route("api/workflow/removeStage")]
        [HttpPut]
        public async Task<ResponseDTO<string>> RemoveQuestion(WorkflowStageInfoDTO stage)
        {
            try
            {
                await _workflowRepo.DeleteStage(stage.WorkflowId, stage.StageInfo);
                await _stageRepo.Delete(stage.StageInfo);
                ResponseDTO<string> response = new(200, "Stage Has Been Deleted Successfully", "DELETED");
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<string> response = new(500, "Internal Server Error", "NOT DELETED");
                return response;
            }
        }
    }
}
