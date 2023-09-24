
using ProgramCreation.Models;

namespace ProgramCreation.DTOs
{
    //Contains the Stage itself and the work flow it will be added in as this will be used while adding a stage
    public class WorkflowStageDTO
    {
        public StageDTO? Stage { get; set; }
        public string workflowId { get; set; }
    }
}
